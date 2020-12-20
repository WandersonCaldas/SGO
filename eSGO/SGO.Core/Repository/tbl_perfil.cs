using SGO.Core.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SGO.Core.Repository
{
    public class tbl_perfil
    {
        public List<Model.tbl_perfil> Listar()
        {
            var cn = Conexao.GetInstance().GetConnection;
            return cn.Query<Model.tbl_perfil>("SELECT * FROM tbl_perfil").ToList();
        }

        public Model.tbl_perfil Consultar(int id)
        {
            var cn = Conexao.GetInstance().GetConnection;
            return cn.Query<Model.tbl_perfil>("SELECT * FROM tbl_perfil WHERE cod_perfil = " + id).FirstOrDefault();
        }
    }
}
