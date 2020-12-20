using AutoMapper;
using SGO.Core.Model;
using SGO.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO.Core.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<tbl_perfil, PerfilViewModel>();
            CreateMap<tbl_empresa, EmpresaViewModel>();
            CreateMap<tbl_usuario, UsuarioViewModel>();
        }
    }
}
