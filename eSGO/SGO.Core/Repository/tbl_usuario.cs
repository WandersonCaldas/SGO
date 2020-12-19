using Dapper;
using SGO.Core.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO.Core.Repository
{
    public class tbl_usuario
    {
        public List<tbl_usuario> Listar()
        {
            var cn = Conexao.GetInstance().GetConnection;
            return cn.Query<tbl_usuario>("SELECT * FROM tbl_usuario").ToList();
        }

        public tbl_usuario Consultar(int id)
        {
            var cn = Conexao.GetInstance().GetConnection;
            return cn.Query<tbl_usuario>("SELECT * FROM tbl_usuario WHERE cod_usuario = " + id).FirstOrDefault();
        }
    }
}
