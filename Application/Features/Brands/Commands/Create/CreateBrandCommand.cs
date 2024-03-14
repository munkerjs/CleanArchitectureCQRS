using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create;

// CQRS Kullanılacak.

public class CreateBrandCommand : IRequest<CreatedBrandResponse>
{
    // Veritabanında belkide 10 tane kolon var ama biz sadece kullanıcıdan aşağıdaki alanları alacağız.
    // Yani kullanıcının marka oluşturma isteğine göre alınacak alanları aşağıda tanımlıyoruz.

    public string Name { get; set; }

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
    {
        public Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            CreatedBrandResponse response = new CreatedBrandResponse();
            response.Name = request.Name;
            response.Id = new Guid();

            return null;
        }
    }
}

// Her Command'in handler ı vardır.
