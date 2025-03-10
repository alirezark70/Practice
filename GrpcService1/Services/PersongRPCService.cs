using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcService1.Protos;
using static GrpcService1.Protos.PersonService;

namespace GrpcService1.Services
{
    //برای اینکه از کلاس پروتو که درست کردم استفاده کنیم باید اسم کلاس پروتو که ایجاد کردیم
    //به همراه بیس
    //بنویسم
    //بعد متد ها رو اورراید بکنیم
    public class PersongRPCService : PersonServiceBase
    {

        private List<PersonReply> _people = new List<PersonReply>
        {
            new PersonReply
            {
                Id = 1,
                FirstName= "Alireza",
                LastName="Rezaee"
            },
            new PersonReply
            {
                Id = 2,
                FirstName= "Abbas",
                LastName="Rezaee"
            }
        };

        public override async Task GetAll(Empty request, IServerStreamWriter<PersonReply> responseStream, ServerCallContext context)
        {
            foreach (var personReply in _people)
            {
                 await responseStream.WriteAsync(personReply);
            }
        }

        public override async Task<PersonReply> GetPersonById(PersonByIdRequest request, ServerCallContext context)
        {
            var person = _people.FirstOrDefault(e => e.Id == request.Id);

            if (person == null)
                throw new RpcException(new Status( StatusCode.NotFound,"Person Not Found"));

            return person;
        }

        public override async Task CreatePerson(IAsyncStreamReader<CreatePersonRequest> requestStream, IServerStreamWriter<PersonReply> responseStream, ServerCallContext context)
        {
            var id=_people.Count;
           await foreach (var person in requestStream.ReadAllAsync())
            {
                 PersonReply personReply =new PersonReply
                {
                    Id=id++,
                    FirstName=person.FirstName,
                    LastName=person.LastName
                };

                _people.Add(personReply);
                await responseStream.WriteAsync(personReply);
            }


        }

        public override async Task<Empty> UpdatePerson(UpdatePersonRequest request, ServerCallContext context)
        {
            var person=_people.FirstOrDefault(e=> e.Id==request.Id);

            if(person is not null)
            {
                person.FirstName=request.FirstName;
                person.LastName=request.LastName;

            }

            return new Empty();
        }

        public override Task<Empty> DeletePerson(IAsyncStreamReader<PersonByIdRequest> requestStream, ServerCallContext context)
        {
            return base.DeletePerson(requestStream, context);
        }
    }
}
