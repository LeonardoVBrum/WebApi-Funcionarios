using System.Text.Json.Serialization;

namespace WebApi.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartamentoEnum
    {
        RH,
        Financeiro,
        Compras,
        Atendimento,
        Portaria
    }
}
