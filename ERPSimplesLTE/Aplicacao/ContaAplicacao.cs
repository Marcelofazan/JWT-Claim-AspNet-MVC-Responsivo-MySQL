using ERPSimplesLTE.Models;
using ERPSimplesLTE.Repositorio;
using System.Collections.Generic;
using System.Linq;

namespace ERPSimplesLTE.Aplicacao
{
    public class ContaAplicacao
    {
        private readonly Contexto contexto;

        public ContaAplicacao()
        {
            contexto = new Contexto();
        }

        public Usuario ValidarLogin(string email, string senha)
        {
            var usuarios = new List<Usuario>();
            const string strQuery = "SELECT IdUsuario, Nome, Email, Senha FROM Usuarios WHERE Email = @email AND Senha = @senha";

            var parametros = new Dictionary<string, object>
                {
                    {"Email", email},
                    {"Senha", senha},
                };

            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempUsuario = new Usuario
                {
                    Id = int.Parse(!string.IsNullOrEmpty(row["IdUsuario"]) ? row["IdUsuario"] : "0"),
                    Nome = row["Nome"],
                    Email = row["Email"],
                    Senha = row["Senha"]
                };
                usuarios.Add(tempUsuario);
            }

            return usuarios.FirstOrDefault();
        }

    }
}