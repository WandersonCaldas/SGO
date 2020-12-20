using Dapper;
using SGO.Core.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO.Core.Repository
{
    public class tbl_empresa
    {
        public List<Model.tbl_empresa> Listar()
        {
            var cn = Conexao.GetInstance().GetConnection;
            return cn.Query<Model.tbl_empresa>("SELECT * FROM tbl_empresa").ToList();
        }

        public Model.tbl_empresa Consultar(int id)
        {
            var cn = Conexao.GetInstance().GetConnection;
            return cn.Query<Model.tbl_empresa>("SELECT * FROM tbl_empresa WHERE cod_empresa = " + id).FirstOrDefault();
        }
    }
}
