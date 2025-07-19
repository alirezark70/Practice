using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyInCSharp
{
    public class syncSeviceUser
    {
        public syncSeviceUser()
        {
            
        }
        public int Id { get; set; }

        public string Name { get; set; }
    }
    public class SyncService
    {

        IEnumerable<syncSeviceUser> GetSyncSeviceUsers()
        {
            
            for (int i = 0; i < 100; i++)
            {
                yield return new syncSeviceUser { Id = i, Name = $"Sample{i}" };
            }
        }

        public void GetUserFromLegacyApi(Action<IEnumerable<syncSeviceUser>> onSuccess, Action<Exception> onError)
        {
            // فرضاً بعد از چند لحظه
            System.Threading.Timer timer = null;
            timer = new System.Threading.Timer(_ =>
            {
                timer.Dispose();
                onSuccess(GetSyncSeviceUsers());
            }, null, 2000, System.Threading.Timeout.Infinite);
        }
    }


    public class AsyncService
    {
        public Task<IEnumerable<syncSeviceUser>> GetUsersAsync()
        {
            SyncService syncService = new SyncService();
            var tcs = new TaskCompletionSource<IEnumerable<syncSeviceUser>>();

            syncService.GetUserFromLegacyApi(
               onSuccess: result => tcs.SetResult(result),
               onError: ex => tcs.SetException(ex)

             );

            return tcs.Task;
        }
    }


    //public interface IGetFromSyncService
    //{
    //    void GetUserFromLegacyApi<T>(Action<T> onSuccess, Action<Exception> onError) where T : class;
    //}

    //public class GetFromSyncService : IGetFromSyncService
    //{
    //    public void GetUserFromLegacyApi<T>(Action<T> onSuccess, Action<Exception> onError) where T : class
    //    {
    //        System.Threading.Timer timer = null;
    //        timer = new System.Threading.Timer(_ =>
    //        {
    //            timer.Dispose();
    //            var instance =  T; // نمونه می‌سازیم
    //            onSuccess(instance);
    //        }, null, 2000, System.Threading.Timeout.Infinite);
    //    }
    //}
}
