using Dapper;
using SGO.Core.Repository.Context;
using SGO.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGO.Core.Repository
{
    public class tbl_usuario
    {
        public List<Model.tbl_usuario> Listar()
        {
            var cn = Conexao.GetInstance().GetConnection;
            return cn.Query<Model.tbl_usuario>("SELECT * FROM tbl_usuario").ToList();
        }

        public Model.tbl_usuario Consultar(int id)
        {
            var cn = Conexao.GetInstance().GetConnection;
            return cn.Query<Model.tbl_usuario>("SELECT * FROM tbl_usuario WHERE cod_usuario = " + id).FirstOrDefault();
        }

        public void AtualizarSenha(Model.tbl_usuario obj)
        {
            Model.tbl_usuario retorno = new Model.tbl_usuario();

            using (var cn = Conexao.GetInstance().GetConnection)
            {
                retorno = new Model.tbl_usuario();

                var sql = @"UPDATE tbl_usuario SET txt_senha = @txt_senha WHERE txt_email = @txt_email";
                cn.Execute(sql, new
                {
                    txt_senha = obj.txt_senha.Trim(),
                    txt_email = obj.txt_email.Trim()
                });
            }            
        }
    }
}
