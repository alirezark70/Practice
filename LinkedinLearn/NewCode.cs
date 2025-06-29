using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedinLearn
{
    internal class NewCode
    {
    }

    //کد زیر باید بررسی شود


    public interface IIndicatorRule
    {
        IndicatorType RuleFor { get; }

        IEnumerable<IndicatorItemDto> Evaluate(IndicatorContextDto ctx);
    }

    public interface IJobsSnapshotProvider
    {
        Task<JobsSnapshotDto> BuildAsync(string nationalCode,
                                  int? currentAgencyId,
                                  int? currentApplicantRequestId,
                                  IndicatorEntityType entityType);
    }

    public record class IndicatorContextDto(
    string NationalCode,
    IndicatorEntityType IndicatorEntityType,
    int? CurrentAgencyId,
    int? CurrentApplicantRequestId,
    JobsSnapshotDto jobs);


    public sealed class JobsSnapshotDto
    {
        public List<AgencyMemberForIndicatorDto> AgencyMembers { get; set; }
        public List<MarketerWithNaturalPersonDto> Marketers { get; set; }
        public List<EmployeeWithNaturalPersonDto> Employees { get; set; }
        public List<BoardMemberWithNaturalPersonDto> BoardMembers { get; set; }
        public List<ShareholderWithNaturalPersonDto> Shareholders { get; set; }
        public List<BoardMemberWithNaturalPersonDto> Inspectors { get; set; }
        public List<OfficeDto> Offices { get; set; }
    }

    public sealed class JobsSnapshotProvider : IJobsSnapshotProvider
    {
        private readonly IAgencyMemberService _agencyMemberService;
        private readonly IMarketerService _marketerService;
        private readonly IEmployeeService _employeeService;
        private readonly IShareholderService _shareholderService;
        private readonly IBoardMemberService _boardMemberService;
        private readonly IOfficeService _officeService;

        public JobsSnapshotProvider(IAgencyMemberService agencyMemberService,
            IMarketerService marketerService,
            IEmployeeService employeeService,
            IShareholderService shareholderService,
            IBoardMemberService boardMemberService,
            IOfficeService officeService,
            IApplicantRequestService requestService)
        {
            _agencyMemberService = agencyMemberService;
            _marketerService = marketerService;
            _employeeService = employeeService;
            _shareholderService = shareholderService;
            _boardMemberService = boardMemberService;
            _officeService = officeService;
        }


        public async Task<JobsSnapshotDto> BuildAsync(string nationalCode,
            int? currentAgencyId,
            int? currentApplicantRequestId,
            IndicatorEntityType entityType)
        {
            var (agencyMembers, marketers, employees, boardMembers, shareholders, inspectors, offices) = await GetJobsOfNationalCode(nationalCode, currentAgencyId);

            if (currentAgencyId.HasValue && entityType != IndicatorEntityType.Inspector)
            {
                agencyMembers = CheckAndFilterInTheSameAgencyForCEOAndOfficer(
                                    currentAgencyId, entityType, agencyMembers, offices);

                (employees, marketers, shareholders, boardMembers)
                        = CheckAndFilterInTheSameAgencyForEmployeesAndMarketersAndShareholdersAndBoardMembers(
                              currentAgencyId, marketers, employees, boardMembers, shareholders);
            }

            return new JobsSnapshotDto
            {
                AgencyMembers = agencyMembers,
                Marketers = marketers,
                Employees = employees,
                BoardMembers = boardMembers,
                Shareholders = shareholders,
                Inspectors = inspectors,
                Offices = offices,
            };
        }

        private async Task<(List<AgencyMemberForIndicatorDto>,
                            List<MarketerWithNaturalPersonDto>,
                            List<EmployeeWithNaturalPersonDto>,
                            List<BoardMemberWithNaturalPersonDto>,
                            List<ShareholderWithNaturalPersonDto>,
                            List<BoardMemberWithNaturalPersonDto>,
                            List<OfficeDto>)> GetJobsOfNationalCode(string nationalCode, int? currentAgencyId)
        {
            var agencyMembersTask = _agencyMemberService.GetAgencyMembersForIndicatorAsync(nationalCode);
            var marketersTask = _marketerService.GetMarketersByNationalCodeForIndicatorItemsAsync(nationalCode);
            var employeesTask = _employeeService.GetEmployeesByNationalCodeForIndicatorItemsAsync(nationalCode);
            var boardMembersTask = _boardMemberService.GetBoardMembersByNationalCodeForIndicatorItemsAsync(nationalCode);
            var shareholdersTask = _shareholderService.GetShareholdersByNationalCodeIndicatorItemsAsync(nationalCode);
            var offices = currentAgencyId is not null && currentAgencyId != 0 ? _officeService.GetOfficesByAgencyIdAsync(currentAgencyId.Value) : Task.FromResult<IEnumerable<Office>>(new List<Office>());

            await Task.WhenAll(agencyMembersTask, marketersTask, employeesTask, boardMembersTask, shareholdersTask, offices);

            var boardMembers = await boardMembersTask;
            var inspectors = boardMembers.Where(w => w.BoardMemberPosition is BoardMemberPosition.Inspector or BoardMemberPosition.AlternativeInspector).ToList();

            return (await agencyMembersTask, await marketersTask, await employeesTask, boardMembers, await shareholdersTask, inspectors,
                   (await offices).ToDto<OfficeDto>().ToList());
        }

        private List<AgencyMemberForIndicatorDto> CheckAndFilterInTheSameAgencyForCEOAndOfficer(int? currentAgencyId, IndicatorEntityType indicatorEntityType,
                                                                                                List<AgencyMemberForIndicatorDto> activeAgencyMembers, List<OfficeDto> offices)
        {
            //نماینده حقیقی
            if (indicatorEntityType != IndicatorEntityType.CEO && indicatorEntityType != IndicatorEntityType.Officer)
                return activeAgencyMembers.Where(am => am.AgencyId != currentAgencyId).ToList();

            //نماینده حقوقی
            else if (indicatorEntityType == IndicatorEntityType.CEO)
                return activeAgencyMembers.Where(am => am.AgencyId != currentAgencyId || PersonIsActiveOfficer(offices, am)).ToList();


            //مسئوا شعبه
            else if (indicatorEntityType == IndicatorEntityType.Officer || PersonIsActiveOfficer(offices, activeAgencyMembers))
                return activeAgencyMembers.Where(am => am.AgencyId != currentAgencyId ||
                                                      (am.AgencyMemberPosition == AgencyMemberPosition.CEO && am.EndDateTime is null)).ToList();
            return activeAgencyMembers;
        }



        private (List<EmployeeWithNaturalPersonDto>, List<MarketerWithNaturalPersonDto>
               , List<ShareholderWithNaturalPersonDto>, List<BoardMemberWithNaturalPersonDto>) CheckAndFilterInTheSameAgencyForEmployeesAndMarketersAndShareholdersAndBoardMembers(
                                                                                        int? currentAgencyId,
                                                                                        List<MarketerWithNaturalPersonDto> marketers,
                                                                                        List<EmployeeWithNaturalPersonDto> employees,
                                                                                        List<BoardMemberWithNaturalPersonDto> boardMembers,
                                                                                        List<ShareholderWithNaturalPersonDto> shareholders) =>

            (employees.Where(w => w.AgencyId != currentAgencyId).ToList(),
             marketers.Where(w => w.AgencyId != currentAgencyId).ToList(),
             shareholders.Where(w => w.AgencyId != currentAgencyId).ToList(),
             boardMembers.Where(w => w.AgencyId != currentAgencyId).ToList());


        private bool PersonIsActiveOfficer(List<OfficeDto> offices, AgencyMemberForIndicatorDto activeAgencyMember) =>
            offices.Any(o => activeAgencyMember.AgencyMemberId == o.OfficerAgencyMemberId && activeAgencyMember.EndDateTime is null);

        private bool PersonIsActiveOfficer(List<OfficeDto> offices, List<AgencyMemberForIndicatorDto> activeAgencyMembers) =>
            offices.Any(o => activeAgencyMembers.Any(am => am.AgencyMemberId == o.OfficerAgencyMemberId && am.EndDateTime is null));
    }

    public static class IndicatorItemFactory
    {
        public static IndicatorItemDto CreateMultipleJob(LegacyStatus statusId,
                                                         LegacyTypeTitle typeId,
                                                         LegacyPostName? positionId = null,
                                                         object additionalData = null)
        {
            return new IndicatorItemDto
            {
                PositionId = positionId,
                StatusId = statusId,
                TypeId = typeId,
                IndicatorItemType = IndicatorItemType.MultipleJob,
                AdditionalData = additionalData != null ? JsonConvert.SerializeObject(additionalData) : "",
                CreatedDateTime = DateTime.Now
            };
        }
    }

    #region Rules
    public sealed class ActiveRequestRule : IIndicatorRule
    {
        private readonly IApplicantRequestService _requestService;

        public ActiveRequestRule(IApplicantRequestService requestService)
        {
            _requestService = requestService;
        }

        public IndicatorType RuleFor => IndicatorType.ActiveRequest;

        public IEnumerable<IndicatorItemDto> Evaluate(IndicatorContextDto ctx)
        {
            if (ctx.CurrentApplicantRequestId is null or 0)
                return Enumerable.Empty<IndicatorItemDto>();



            var hasActive = _requestService
                            .HasActiveRequestsAsync(ctx.NationalCode,
                                                    ctx.CurrentApplicantRequestId!.Value,
                                                    ctx.CurrentAgencyId)
                            .GetAwaiter()
                            .GetResult();

            if (!hasActive)
                return Enumerable.Empty<IndicatorItemDto>();

            var item = IndicatorItemFactory.CreateMultipleJob(
                           LegacyStatus.PrimaryEnrollment,
                           LegacyTypeTitle.Agency);

            return new[] { item };

        }

    }

    public sealed class BoardMemberRule : IIndicatorRule
    {
        public IndicatorType RuleFor => IndicatorType.BoardMember;

        public IEnumerable<IndicatorItemDto> Evaluate(IndicatorContextDto ctx)
        {
            var members = ctx.jobs.BoardMembers.ToList();

            if (ctx.CurrentAgencyId.HasValue &&
                ctx.IndicatorEntityType != IndicatorEntityType.BoardMember)
            {
                members = members
                          .Where(b => b.AgencyId != ctx.CurrentAgencyId)
                          .ToList();
            }

            if (members.Count == 0)
                return Enumerable.Empty<IndicatorItemDto>();

            var result = members.Select(b =>
                IndicatorItemFactory.CreateMultipleJob(
                    LegacyStatus.Active,
                    LegacyTypeTitle.Agency,
                    LegacyPostName.MemberOfTheBoard,
                    new
                    {
                        b.AgencyCompanyCode,
                        b.CompanyName,
                        b.BoardMemberPosition,
                        b.BoardMemberStatus,
                    }));

            return result;
        }
    }

    public sealed class EmployeeRule : IIndicatorRule
    {
        public IndicatorType RuleFor => IndicatorType.Employee;

        public IEnumerable<IndicatorItemDto> Evaluate(IndicatorContextDto ctx)
        {

            var employees = ctx.jobs.Employees.ToList();

            if (ctx.CurrentAgencyId.HasValue &&
                ctx.IndicatorEntityType != IndicatorEntityType.Employee)
            {
                employees = employees
                            .Where(e => e.AgencyId != ctx.CurrentAgencyId)
                            .ToList();
            }

            if (employees.Count == 0)
                return Enumerable.Empty<IndicatorItemDto>();


            var result = employees.Select(e =>
                IndicatorItemFactory.CreateMultipleJob(
                    LegacyStatus.Active,
                    LegacyTypeTitle.Agency,
                    LegacyPostName.TechnicalEmployeeAndInsurance,
                    new
                    {
                        e.AgencyCompanyCode,
                        e.CompanyName
                    }));

            return result;
        }
    }
    public sealed class InsuranceMemberRule : IIndicatorRule
    {
        //currect
        public IndicatorType RuleFor => IndicatorType.InsuranceMember;

        public IEnumerable<IndicatorItemDto> Evaluate(IndicatorContextDto ctx)
        {
            var InsuranceMemberList = ctx.jobs.ActiveAgencyMembers.Where(e => e.AgencyMemberPosition == Domain.Enums.AgencyMembers.AgencyMemberPosition.InsuranceMember);

            if (ctx.CurrentAgencyId.HasValue)
                InsuranceMemberList = InsuranceMemberList
                          .Where(e => e.AgencyId != ctx.CurrentAgencyId)
                          .ToList();

            if (InsuranceMemberList.Count() == 0)
                return Enumerable.Empty<IndicatorItemDto>();

            var result = InsuranceMemberList.Select(e =>
                IndicatorItemFactory.CreateMultipleJob(
                    LegacyStatus.Active,
                    LegacyTypeTitle.Agency,
                    LegacyPostName.InsuranceMemberOfTheBoard,
                    new
                    {
                        LegacyStatus.Active,
                        LegacyTypeTitle.Agency,
                        LegacyPostName.InsuranceMemberOfTheBoard,

                    }));

            return result;
        }
    }
    public sealed class JuridicalAgencyCeoRule : IIndicatorRule
    {
        //currect
        public IndicatorType RuleFor => IndicatorType.JuridicalAgencyCEO;

        public IEnumerable<IndicatorItemDto> Evaluate(IndicatorContextDto ctx)
        {

            var ceos = ctx.jobs.ActiveAgencyMembers
                      .Where(m => m.AgencyMemberPosition == AgencyMemberPosition.CEO)
                      .ToList();

            if (ctx.CurrentAgencyId.HasValue &&
                ctx.IndicatorEntityType is not (IndicatorEntityType.CEO or IndicatorEntityType.Officer))
                ceos = ceos.Where(c => c.AgencyId != ctx.CurrentAgencyId).ToList();

            return ceos.Select(c =>
                IndicatorItemFactory.CreateMultipleJob(LegacyStatus.Active,
                                                       LegacyTypeTitle.Agency,
                                                       LegacyPostName.CEO,
                                                       new { c.AgencyCompanyCode, c.CompanyName }));

        }
    }

    public sealed class LifeAgencyRule : IIndicatorRule
    {
        //currect
        public IndicatorType RuleFor => IndicatorType.LifeAgency;

        private readonly IAgencyMemberService _agencyMemberService;

        public LifeAgencyRule(IAgencyMemberService agencyMemberService)
            => _agencyMemberService = agencyMemberService;

        public IEnumerable<IndicatorItemDto> Evaluate(IndicatorContextDto ctx)
        {

            var members = ctx.jobs.ActiveAgencyMembers;


            var lifeManagers = members
                               .Where(m => m.AgencyMemberPosition == AgencyMemberPosition.Manager &&
                                           (m.ArticleType == ArticleType.Article96 || m.ArticleType == ArticleType.Article54))
                               .ToList();


            if (ctx.CurrentAgencyId.HasValue &&
                ctx.IndicatorEntityType != IndicatorEntityType.Manager)
            {
                lifeManagers = lifeManagers
                               .Where(m => m.AgencyId != ctx.CurrentAgencyId)
                               .ToList();
            }

            if (!lifeManagers.Any())
                return Enumerable.Empty<IndicatorItemDto>();


            return lifeManagers.Select(lm =>
            {
                var additionalData = new AgencyAdditionalData
                {
                    AgencyCompanyCode = lm.AgencyCompanyCode,
                    CompanyName = lm.CompanyName
                };

                return IndicatorItemFactory.CreateMultipleJob(
                           LegacyStatus.Active,
                           LegacyTypeTitle.Agency,
                           LegacyPostName.LifeInsuranceAgency,
                           additionalData);
            });
        }
    }

    public sealed class MarketerRule : IIndicatorRule
    {
        public IndicatorType RuleFor => IndicatorType.Marketer;

        public IEnumerable<IndicatorItemDto> Evaluate(IndicatorContextDto ctx)
        {

            var marketers = ctx.jobs.Marketers.ToList();

            if (ctx.CurrentAgencyId.HasValue &&
                ctx.IndicatorEntityType != IndicatorEntityType.Marketer)
            {
                marketers = marketers
                            .Where(m => m.AgencyId != ctx.CurrentAgencyId)
                            .ToList();
            }

            if (marketers.Count == 0)
                return Enumerable.Empty<IndicatorItemDto>();

            // ۳) تبدیل به خروجی شاخص  
            var result = marketers.Select(m =>
                IndicatorItemFactory.CreateMultipleJob(
                    LegacyStatus.Active,
                    LegacyTypeTitle.Agency,
                    LegacyPostName.Marketer,
                    new
                    {
                        m.AgencyCompanyCode,
                        m.CompanyName,
                    }));

            return result;
        }
    }

    public sealed class NaturalAgencyManagerRule : IIndicatorRule
    {
        //Currect
        public IndicatorType RuleFor => IndicatorType.NaturalAgencyManager;

        public IEnumerable<IndicatorItemDto> Evaluate(IndicatorContextDto ctx)
        {

            var managers = ctx.jobs.ActiveAgencyMembers
                                  .Where(m => m.AgencyMemberPosition == AgencyMemberPosition.Manager &&
                                              m.ArticleType != ArticleType.Article96)
                                  .ToList();


            if (ctx.CurrentAgencyId.HasValue &&
                ctx.IndicatorEntityType != IndicatorEntityType.Manager)
            {
                managers = managers.Where(m => m.AgencyId != ctx.CurrentAgencyId).ToList();
            }

            if (!managers.Any())
                return Enumerable.Empty<IndicatorItemDto>();

            var result = managers.Select(m =>
                IndicatorItemFactory.CreateMultipleJob(
                    LegacyStatus.Active,
                    LegacyTypeTitle.Agency,
                    LegacyPostName.PrivateAgent,
                    new { m.AgencyCompanyCode, m.CompanyName }));

            return result;
        }
    }

    public class OfficerRule : IIndicatorRule
    {
        public IndicatorType RuleFor => IndicatorType.Officer;

        public IEnumerable<IndicatorItemDto> Evaluate(IndicatorContextDto ctx)
        {

            var officers = ctx.jobs.ActiveAgencyMembers
                               .Where(m => m.AgencyMemberPosition == AgencyMemberPosition.Officer)
                               .ToList();


            if (ctx.CurrentAgencyId.HasValue &&
                ctx.IndicatorEntityType != IndicatorEntityType.Officer)
            {
                officers = officers.Where(o => o.AgencyId != ctx.CurrentAgencyId).ToList();
            }

            if (officers.Count == 0)
                return Enumerable.Empty<IndicatorItemDto>();


            var result = officers.Select(o =>
                IndicatorItemFactory.CreateMultipleJob(
                    LegacyStatus.Active,
                    LegacyTypeTitle.Agency,
                    LegacyPostName.Officer,
                    new
                    {
                        o.AgencyCompanyCode,
                        o.CompanyName
                    }));

            return result;
        }
    }

    public sealed class ShareholderRule : IIndicatorRule
    {
        public IndicatorType RuleFor => IndicatorType.Shareholder;

        public IEnumerable<IndicatorItemDto> Evaluate(IndicatorContextDto ctx)
        {
            var holders = ctx.jobs.Shareholders.ToList();

            if (ctx.CurrentAgencyId.HasValue &&
                ctx.IndicatorEntityType != IndicatorEntityType.Shareholder)
            {
                holders = holders
                          .Where(h => h.AgencyId != ctx.CurrentAgencyId)
                          .ToList();
            }

            if (holders.Count == 0)
                return Enumerable.Empty<IndicatorItemDto>();


            var result = holders.Select(h =>
                IndicatorItemFactory.CreateMultipleJob(
                    LegacyStatus.Active,
                    LegacyTypeTitle.Agency,
                    LegacyPostName.Shareholder_Agency,
                    new
                    {
                        h.AgencyCompanyCode,
                        h.CompanyName,
                        h.ShareholderStatus
                    }));

            return result;
        }
    }
    #endregion


}
