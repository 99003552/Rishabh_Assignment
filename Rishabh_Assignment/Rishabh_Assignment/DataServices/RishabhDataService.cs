using Rishabh_Assignment.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Rishabh_Assignment.Comman;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Rishabh_Assignment.DataServices
{
    public class RishabhDataService
    {
        private static readonly RishabhDataService _instance = new RishabhDataService();
        public static RishabhDataService Instance
        {
            get => _instance;
        }
        public RishabhDataService()
        {
            
        }
        public async Task<LoginResponce> LoginUser(Object payload)
        {
            try
            {
                var results = await HTTPHelper.SendPostRequest(Comman.AppConstatnts.WebConstants.Login, payload, false);
                return JsonConvert.DeserializeObject<LoginResponce>(results);
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<UserResponce> GetUsers(Dictionary<string,object> perameters)
        {
            try
            {
                var result = await HTTPHelper.SendGetRequest(AppConstatnts.WebConstants.Users, perameters);
                return JsonConvert.DeserializeObject<UserResponce>(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ProfileResponce> GetProfile(Dictionary<string, object> perameters)
        {
            try
            {
                var result = await HTTPHelper.SendGetRequest(AppConstatnts.WebConstants.Profile, perameters);
                return JsonConvert.DeserializeObject<ProfileResponce>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
