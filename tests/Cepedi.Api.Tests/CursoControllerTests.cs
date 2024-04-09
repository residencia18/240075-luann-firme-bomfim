using MediatR;
using NSubstitute;
using Cepedi.WebApi.Controllers;
using Cepedi.Shareable.Requests;

namespace Cepedi.WebApi.Tests
{
    public class CursoControllerTests
    {
        private readonly IMediator _mediator = Substitute.For<IMediator>();
        private readonly CursoController _sut;

        [Fact]
        public async Task ConsultarCurso_DeveEnviarRequest_Para_Mediator()
        {
            // Arrange 
            var request = new ObtemCursoRequest(1);
            CancellationToken cancellationToken = CancellationToken.None;

            // Act
            await _sut.ConsultarCursoAsync(1, cancellationToken);

            // Assert
            await _mediator.ReceivedWithAnyArgs().Send(request);
        }
    }
}
