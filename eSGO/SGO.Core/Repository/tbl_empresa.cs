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
        public List<tbl_empresa> Listar()
        {
            var cn = Conexao.GetInstance().GetConnection;
            return cn.Query<tbl_empresa>("SELECT * FROM tbl_empresa").ToList();
        }

        public tbl_empresa Consultar(int id)
        {
            var cn = Conexao.GetInstance().GetConnection;
            return cn.Query<tbl_empresa>("SELECT * FROM tbl_empresa WHERE cod_empresa = " + id).FirstOrDefault();
        }
    }
}
