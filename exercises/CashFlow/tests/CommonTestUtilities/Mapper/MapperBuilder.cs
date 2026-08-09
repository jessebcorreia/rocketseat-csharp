using AutoMapper;
using CashFlow.Application.Automapper;
using Microsoft.Extensions.Logging.Abstractions;

namespace CommonTestUtilities.Mapper;

public class MapperBuilder
{
    public static IMapper Build()
    {
        /*
         * No projeto CashFlow.Application, o AutoMapper é configurado pelo Dependency Injection: services.AddAutoMapper(cfg => { }, typeof(AutoMapping));
         *
         * Como este teste não utiliza o container de DI da aplicação, preciso configurar o AutoMapper manualmente.
         *
         * Adicionei o mesmo Profile (AutoMapping) utilizado pela aplicação, para garantir que os testes usem os mesmos mapeamentos.
         *
         * O NullLoggerFactory fornece o ILoggerFactory exigido pelo AutoMapper, sem precisar configurar logging para os testes.
         */
        var configuration = new MapperConfigurationExpression();

        configuration.AddProfile<AutoMapping>();

        var mapper = new MapperConfiguration(
            configuration,
            NullLoggerFactory.Instance);

        return mapper.CreateMapper();
    }
}
