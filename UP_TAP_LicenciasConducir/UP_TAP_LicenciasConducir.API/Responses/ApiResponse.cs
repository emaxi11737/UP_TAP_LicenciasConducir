using UP_TAP_LicenciasConducir.Core.CustomEntities;

namespace UP_TAP_LicenciasConducir.API.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public Metadata Meta { get; set; }
    }
}
