using Mc2.CrudTest.Presentation.Shared;

namespace Mc2.CrudTest.Presentation.Client.Services
{
    public class CustomersService : Infrastructure.ServiceBase
    {
        // ********************
        #region Properties

        private readonly HttpClient _httpClient;

        // ********************
        #endregion

        public CustomersService
            (
                HttpClient httpClient

            ) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response<List<CustomerReadViewModel>>> GetAllAsync()
        {
            string url = $"Customer";

            var result = await GetAsync<Response<List<CustomerReadViewModel>>>(url: url);

            return result;
        }



        public async
           Task
           <CustomerReadViewModel>
           GetByIdAsync(int Id)
        {
            string url = $"Customer/GetById";

            var result =
                await
                GetByIdAsync

                <CustomerReadViewModel>
                (url: url, Id);

            return result;
        }

    }
}
