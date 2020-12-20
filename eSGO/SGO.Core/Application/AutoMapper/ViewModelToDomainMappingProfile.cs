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
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            // trim todas strings
            CreateMap<string, string>()
                .ConvertUsing(x => (x ?? "").Trim());

            CreateMap<PerfilViewModel, tbl_perfil>();
            CreateMap<EmpresaViewModel, tbl_empresa>();
            CreateMap<UsuarioViewModel, tbl_usuario>();
        }
    }
}
