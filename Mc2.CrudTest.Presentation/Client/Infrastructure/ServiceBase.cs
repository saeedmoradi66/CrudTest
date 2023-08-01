using Newtonsoft.Json;
using System;
using System.Net.Http.Json;
using System.Text.Json;
using JsonException = Newtonsoft.Json.JsonException;

namespace Mc2.CrudTest.Presentation.Client.Infrastructure
{
	public abstract class ServiceBase : object
	{
		// ********************
		#region Properties

		protected string BaseUrl { get; set; }
		protected HttpClient Http { get; }


		// ********************
		#endregion
		public ServiceBase
			(
				HttpClient http
			) : base()
		{
			Http = http;
			BaseUrl = Utility.getBaseUrl();
		}

		protected virtual
			async Task<TResponse>
			GetAsync<TResponse>(string url, string query = null, bool isAddTokenToHeader = true)
		{
			HttpResponseMessage response = null;

			try
			{
				string requestUri = $"{BaseUrl}/{url}";
				if (string.IsNullOrWhiteSpace(query) == false)
				{
					requestUri = $"{requestUri}?{query}";
				}

				response =
					await
					Http.GetAsync
					(requestUri: requestUri)
					;
				string strTypeResponse = response.GetType().ToString();

				response.EnsureSuccessStatusCode();

				if (response.IsSuccessStatusCode)
				{
					try
					{
						strTypeResponse = typeof(TResponse).ToString();

						////ReadFromJsonAsync->Extension Method-> using Json;
						//TResponse result =
						//	await
						//	response.Content.ReadFromJsonAsync<TResponse>();

						string jsonResponse = await response.Content.ReadAsStringAsync();
						TResponse result = JsonConvert.DeserializeObject<TResponse>(jsonResponse);

						return result;
					}

					// When content type is not valid
					catch (NotSupportedException ex)
					{
						string errorMessage =
							$"Exception: {ex.Message} - The content type is not supported.";


					}

					// Invalid JSON
					catch (JsonException ex)
					{
						string errorMessage =
							$"Exception: {ex.Message} - Invalid JSON.";


					}
				}
			}
			catch (HttpRequestException ex)
			{
				string errorMessage =
					$"Exception: {ex.Message}";


			}
			finally
			{
				response.Dispose();
			}

			return default;
		}

		protected virtual
			async Task<TResponse>
			GetByIdAsync<TResponse>(string url, int id, bool isAddTokenToHeader = true)
		{
			HttpResponseMessage response = null;

			try
			{
				string requestUri = $"{BaseUrl}/{url}/{id}";


				response =
					await
					Http.GetAsync
					(requestUri: requestUri)
					;
				string strTypeResponse = response.GetType().ToString();

				response.EnsureSuccessStatusCode();

				if (response.IsSuccessStatusCode)
				{
					try
					{
						strTypeResponse = typeof(TResponse).ToString();

						var options = new JsonSerializerOptions
						{
							PropertyNameCaseInsensitive = true,
							WriteIndented = true,
						};

						//ReadFromJsonAsync->Extension Method-> using Json;
						TResponse result =
							await
							response.Content.ReadFromJsonAsync<TResponse>();
						return result;
					}

					// When content type is not valid
					catch (NotSupportedException ex)
					{
						string errorMessage =
							$"Exception: {ex.Message} - The content type is not supported.";


					}

					// Invalid JSON
					catch (JsonException ex)
					{
						string errorMessage =
							$"Exception: {ex.Message} - Invalid JSON.";


					}
				}
			}
			catch (HttpRequestException ex)
			{
				string errorMessage =
					$"Exception: {ex.Message}";


			}
			finally
			{
				response.Dispose();
			}

			return default;
		}

		protected virtual
			async Task<TResponse>
			FindByIdAsync<TResponse>(string url, int id, bool isAddTokenToHeader = true)
		{
			HttpResponseMessage response = null;

			try
			{
				string requestUri = $"{BaseUrl}/{url}/{id}";



				response =
					await
					Http.GetAsync
					(requestUri: requestUri)
					;
				string strTypeResponse = response.GetType().ToString();

				response.EnsureSuccessStatusCode();

				if (response.IsSuccessStatusCode)
				{
					try
					{
						strTypeResponse = typeof(TResponse).ToString();

						var options = new JsonSerializerOptions
						{
							PropertyNameCaseInsensitive = true,
							WriteIndented = true,
						};

						//ReadFromJsonAsync->Extension Method-> using Json;
						TResponse result =
							await
							response.Content.ReadFromJsonAsync<TResponse>();
						return result;
					}

					// When content type is not valid
					catch (NotSupportedException ex)
					{
						string errorMessage =
							$"Exception: {ex.Message} - The content type is not supported.";


					}

					// Invalid JSON
					catch (JsonException ex)
					{
						string errorMessage =
							$"Exception: {ex.Message} - Invalid JSON.";


					}
				}
			}
			catch (HttpRequestException ex)
			{
				string errorMessage =
					$"Exception: {ex.Message}";


			}
			finally
			{
				response.Dispose();
			}

			return default;
		}

		protected virtual
			async Task<TResponse>
			FindByIdAsync<TResponse>(string url, Guid id, bool isAddTokenToHeader = true)
		{
			HttpResponseMessage response = null;

			try
			{
				string requestUri = $"{BaseUrl}/{url}/{id}";



				response =
					await
					Http.GetAsync
					(requestUri: requestUri)
					;
				string strTypeResponse = response.GetType().ToString();

				response.EnsureSuccessStatusCode();

				if (response.IsSuccessStatusCode)
				{
					try
					{
						strTypeResponse = typeof(TResponse).ToString();

						var options = new JsonSerializerOptions
						{
							PropertyNameCaseInsensitive = true,
							WriteIndented = true,
						};

						//ReadFromJsonAsync->Extension Method-> using Json;
						TResponse result =
							await
							response.Content.ReadFromJsonAsync<TResponse>();
						return result;
					}

					// When content type is not valid
					catch (NotSupportedException ex)
					{
						string errorMessage =
							$"Exception: {ex.Message} - The content type is not supported.";


					}

					// Invalid JSON
					catch (JsonException ex)
					{
						string errorMessage =
							$"Exception: {ex.Message} - Invalid JSON.";


					}
				}
			}
			catch (HttpRequestException ex)
			{
				string errorMessage =
					$"Exception: {ex.Message}";


			}
			finally
			{
				response.Dispose();
			}

			return default;
		}


		// ********************
		protected virtual
			async Task<TResponse>
			PostAsync<TRequest, TResponse>(string url, TRequest viewModel, bool isAddTokenToHeader = true)
		{
			HttpResponseMessage response = null;

			try
			{
				string requestUri = $"{BaseUrl}/{url}";



				response =
					await Http.PostAsJsonAsync
					(requestUri: requestUri, value: viewModel);

				string strTypeResponse = response.GetType().ToString();

				var ensureSuccessStatusCode = response.EnsureSuccessStatusCode();

				if (response.IsSuccessStatusCode)
				{
					try
					{
						strTypeResponse = typeof(TResponse).ToString();
						string strTypeRequest = typeof(TRequest).ToString();


						// New Solution
						TResponse result =
							await response.Content.ReadFromJsonAsync<TResponse>();
						return result;

					}
					// When content type is not valid
					catch (NotSupportedException)
					{
						Console.WriteLine("The content type is not supported.");
					}
					// Invalid JSON
					catch (JsonException)
					{
						Console.WriteLine("Invalid JSON.");
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex);
					}
				}
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				response.Dispose();
				//response = null;
			}

			return default;
		}


		// ********************
		protected virtual
			async Task<TResponse>
			PutAsync<TRequest, TResponse>(string url, TRequest viewModel, bool isAddTokenToHeader = true)
		{
			HttpResponseMessage response = null;

			try
			{

				string requestUri = $"{BaseUrl}/{url}";


				response =
					await Http.PutAsJsonAsync
					(requestUri: requestUri, value: viewModel);

				response.EnsureSuccessStatusCode();

				if (response.IsSuccessStatusCode)
				{
					try
					{
						TResponse result =
							await response.Content.ReadFromJsonAsync<TResponse>();

						return result;
					}
					// When content type is not valid
					catch (NotSupportedException)
					{
						Console.WriteLine("The content type is not supported.");
					}
					// Invalid JSON
					catch (JsonException)
					{
						Console.WriteLine("Invalid JSON.");
					}
				}
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				response.Dispose();
			}

			return default;
		}


		// ********************
		protected virtual
			async Task<TResponse>
			DeleteAsync<TResponse>(string url, int id, bool isAddTokenToHeader = true)
		{
			HttpResponseMessage response = null;

			try
			{
				string requestUri = $"{BaseUrl}/{url}{id}";


				response =
					await Http.DeleteAsync(requestUri: requestUri);

				response.EnsureSuccessStatusCode();

				if (response.IsSuccessStatusCode)
				{
					try
					{
						TResponse result =
							await response.Content.ReadFromJsonAsync<TResponse>();

						return result;
					}
					// When content type is not valid
					catch (NotSupportedException)
					{
						Console.WriteLine("The content type is not supported.");
					}
					// Invalid JSON
					catch (JsonException)
					{
						Console.WriteLine("Invalid JSON.");
					}
				}
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				response.Dispose();
			}

			return default;
		}

		protected virtual
			async Task<TResponse>
			DeleteAsync<TResponse>(string url, Guid id, bool isAddTokenToHeader = true)
		{
			HttpResponseMessage response = null;

			try
			{
				string requestUri = $"{BaseUrl}/{url}{id}";


				response =
					await Http.DeleteAsync(requestUri: requestUri);

				response.EnsureSuccessStatusCode();

				if (response.IsSuccessStatusCode)
				{
					try
					{
						TResponse result =
							await response.Content.ReadFromJsonAsync<TResponse>();

						return result;
					}
					// When content type is not valid
					catch (NotSupportedException)
					{
						Console.WriteLine("The content type is not supported.");
					}
					// Invalid JSON
					catch (JsonException)
					{
						Console.WriteLine("Invalid JSON.");
					}
				}
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				response.Dispose();
			}

			return default;
		}
	}
}
