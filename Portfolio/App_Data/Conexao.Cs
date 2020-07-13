using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

//namespace Portfolio
namespace dados
{
    public class Conexao
    {
        //"connect" é o nome da variável atribuído à string de conexão no arquivo web.config
        //aqui ela é passada como parâmetro à variável "conn" respeitando a sintaxe da linguagem
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());

        //note sgs
        //public String conexao = @"Data Source=BR862L1CBKZ9\SQLEXPRESS;Initial Catalog=projeto;Integrated Security=True";
        //public String conexao = @"Data Source = BR862L1CBKZ9\SQLEXPRESS;Initial Catalog = projeto;User ID = thiersfb; Password=thiers07";

        //note pessoal
        //public String conexao = @"Data Source=THIERS-DELL\SQLSERVER;Initial Catalog=projeto;Integrated Security=True";

        public String conexao = @"Data Source=THIERS-DELL\SQLSERVER;Initial Catalog=projeto;User ID=thiersfb;Password=thiers07;Connect Timeout=10500";
        //public String conexao = @"Data Source = THIERS - DELL\SQLSERVER;Initial Catalog = projeto; Persist Security Info=True;User ID = thiersfb; Password=thiers07";

        SqlDataAdapter da;
        DataSet ds;

        public long DataHoraCompleto()
        {
            long DataHoraCompleto = 0;
            try
            {
                string Ano = "0";
                string Mes = "00";
                string Dia = "00";
                string Hora = "00";
                string Minuto = "00";
                string Segundo = "00";
                DateTime dt = DateTime.Now;
                Ano = DateTime.Now.ToString("yy");
                Mes = dt.Month.ToString("d2");
                Dia = dt.Day.ToString("d2");
                Hora = dt.Hour.ToString("d2");
                Minuto = dt.Minute.ToString("d2");
                Segundo = dt.Second.ToString("d2");
                DataHoraCompleto = Convert.ToInt64(Ano + Mes + Dia + Hora + Minuto + Segundo);
            }
            catch (Exception ex)
            {

            }
            return DataHoraCompleto;
        }

        /// <summary>
        /// Valida se Login e Senha inseridos na página de autenticação estão cadastrados na base de dados
        /// </summary>
        /// <param name="login">Recebe por parâmetro o Login digitado na tela</param>
        /// <param name="senha">Recebe por parâmetro a Senha digitada na tela</param>
        /// <returns>Retorna uma string de resultado da consulta na base de dados</returns>
        public string validaLogin(string login, string senha)
        {
            string result = ""; //variavel de retorno

            //alias necessário para verificação do DataReader
            //string sql = "select count(*) as contador from dbo.tblUsuarios where Login = '" + login + "' and Senha = '" + senha + "'";
            string sql = "select count(*) as contador from dbo.Usuarios where Login = '" + login + "' and Senha = '" + senha + "' and UsuEst = 1";
            SqlConnection conn = new SqlConnection(conexao);
            try
            {
                conn.Open();
                SqlCommand comando = new SqlCommand(sql, conn); //executa o comando passado por parâmetro junto com a conexão
                SqlDataReader dr = comando.ExecuteReader();  //armazena o retorno obtido no objeto passado por parâmetro
                if (dr.Read()) //lê o retorno obtido
                {
                    result = dr["contador"].ToString();  //converte p/ string o alias definido no filtro da consulta ao banco
                }
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// Verifica o tipo de usuário que acessou o sistema
        /// </summary>
        /// <param name="login">Recebe por parâmetro o Login digitado na tela</param>
        /// <param name="senha">Recebe por parâmetro a Senha digitada na tela</param>
        /// <returns>Retorna uma string de resultado da consulta na base de dados</returns>
        public string verificaTipoUsuario(string login, string senha)
        {
            string result = ""; //variavel de retorno
            //string sql = "SELECT Email FROM Ard_User WHERE (Email = '" + user + "')";
            //string sql = "select TipoUsuario from dbo.Usuarios where Login = '" + login + "' and Senha = '" + senha + "'";
            string sql = "select TipoUsuario from dbo.Usuarios where Login = '" + login + "' and Senha = '" + senha + "' and UsuEst = 1";
            SqlConnection conn = new SqlConnection(conexao);
            try
            {
                conn.Open();
                SqlCommand comando = new SqlCommand(sql, conn); //executa o comando passado por parâmetro junto com a conexão
                SqlDataReader dr = comando.ExecuteReader(); //armazena o retorno obtido no objeto passado por parâmetro
                if (dr.Read()) //lê o retorno obtido
                {
                    result = dr["TipoUsuario"].ToString(); //converte p/ string o alias definido no filtro da consulta ao banco
                }
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// Cadastra novo usuário na base de dados p/ autenticação no sistema. Novo usuário é 
        /// inserido como inativo por padrão. Usuário será ativado mediante ação manual do usuário com permissão para tal operação
        /// </summary>
        /// <param name="login">Recebe por parâmetro o Login digitado na tela</param>
        /// <param name="senha">Recebe por parâmetro a Senha digitada na tela</param>
        /// <param name="nome">Recebe por parâmetro o Nome digitado na tela</param>
        /// <param name="sobrenome">Recebe por parâmetro o Sobrenome digitado na tela</param>
        /// <param name="cpf">Recebe por parâmetro o CPF digitado na tela</param>
        /// <param name="rg">Recebe por parâmetro o RG digitado na tela</param>
        /// <param name="email">Recebe por parâmetro o E-mail digitado na tela</param>
        /// <param name="endereco">Recebe por parâmetro o Endereço digitado na tela</param>
        /// <param name="cep">Recebe por parâmetro o CEP digitado na tela</param>
        /// <param name="telefone">Recebe por parâmetro o Telefone digitado na tela</param>
        /// <param name="celular">Recebe por parâmetro o Celular digitado na tela</param>
        /// <returns>Retorna uma string de resultado da consulta na base de dados</returns>
        public string registraNovoUsuario(string login, string senha, /*string nome, string sobrenome, string cpf, string rg, */string email/*, string endereco, string cep, string telefone, string celular*/)
        {
            //int tipoUsuario = 3; //tipo 3 = Paciente
            int status = 1; //status de ativação; 1 = ativo, 0 = inativo
            DateTime dob = DateTime.Now; //dob -> date of birth
            DateTime dataRegistro = DateTime.Now;
            DateTime dataUltimaModificacao = DateTime.Now;
            //DateTime dataRegistro = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy");
            //DateTime dataUltimaModificacao = DateTime.Now;
            string result = ""; //variavel de retorno
            string dataNascimento = dob.ToString("yyyy-MM-dd");

            //string sql = "select TipoUsuario from dbo.tblUsuarios where Login = '" + login + "' and Senha = '" + senha + "'";
            //string sql = "SET DATEFORMAT dmy " + //define o formato da data a ser inserida no banco
            //                "INSERT INTO tblUsuarios" +
            //                "(Login, Senha, Nome, Sobrenome, CPF, RG, Email, UsuEst, DataRegistro, " +
            //                "Endereco, CEP, Telefone, Celular, DataUltimaModificacao) " +
            //                " VALUES " +
            string sql = "SET DATEFORMAT dmy " + //define o formato da data a ser inserida no banco
                           "INSERT INTO Usuarios" +
                           "(Login, Senha, Email, DataNascimento, UsuEst, DataRegistro, DataUltimaModificacao, ImagemPerfil) " +
                           " VALUES " +
                           "('" + login + "','"
                                 + senha + "','"
                                 //+ tipoUsuario + "','"
                                 //+ nome + "','"
                                 //+ sobrenome + "','"
                                 //+ cpf + "','"
                                 //+ rg + "','"
                                 + email + "','"
                                 + dataNascimento + "','"
                                 + status + "','"
                                 + dataRegistro + "','"
                                 //+ endereco + "','"
                                 //+ cep + "','"
                                 //+ telefone + "','"
                                 //+ celular + "','"
                                 + dataUltimaModificacao + "','" + "')";
            SqlConnection conn = new SqlConnection(conexao);
            try
            {
                conn.Open();
                SqlCommand comando = new SqlCommand(sql, conn); //executa o comando passado por parâmetro junto com a conexão

                //comando.ExecuteNonQuery(); //executa comando conforme os parâmetros
                int rowsAffected = comando.ExecuteNonQuery();

                result = rowsAffected.ToString();
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// Cadastra novo usuário na base de dados p/ autenticação no sistema. Novo usuário é 
        /// inserido como inativo por padrão. Usuário será ativado mediante ação manual do usuário com permissão para tal operação
        /// </summary>
        /// <param name="login">Recebe por parâmetro o Login digitado na tela</param>
        /// <param name="senha">Recebe por parâmetro a Senha digitada na tela</param>
        /// <param name="nome">Recebe por parâmetro o Nome digitado na tela</param>
        /// <param name="sobrenome">Recebe por parâmetro o Sobrenome digitado na tela</param>
        /// <param name="cpf">Recebe por parâmetro o CPF digitado na tela</param>
        /// <param name="rg">Recebe por parâmetro o RG digitado na tela</param>
        /// <param name="email">Recebe por parâmetro o E-mail digitado na tela</param>
        /// <param name="endereco">Recebe por parâmetro o Endereço digitado na tela</param>
        /// <param name="cep">Recebe por parâmetro o CEP digitado na tela</param>
        /// <param name="telefone">Recebe por parâmetro o Telefone digitado na tela</param>
        /// <param name="celular">Recebe por parâmetro o Celular digitado na tela</param>
        /// <returns>Retorna uma string de resultado da consulta na base de dados</returns>
        /// <returns></returns>
        public string atualizaDadosUsuario(string login, string senha, /*string tipoUsuario, */string nome, string sobrenome, string cpf, string rg, string email, string status, string endereco, string cep, string telefone, string celular, string dataNascimento, string genero, string linkFace, string linkInstagram, string linkLinkedIn, string sobre, string site)
        {
            DateTime dataRegistro = DateTime.Now;
            DateTime dataUltimaModificacao = DateTime.Now;
            string result = ""; //variavel de retorno

            //string sql = "select TipoUsuario from dbo.tblUsuarios where Login = '" + login + "' and Senha = '" + senha + "'";
            string sql = "SET DATEFORMAT dmy " + //define o formato da data a ser inserida no banco
                            "UPDATE Usuarios SET " +
                            " Senha = '" + senha + "'" +
                            //"TipoUsuario = '" + tipoUsuario + "'," +
                            ", Nome = '" + nome + "'" +
                            ", Sobrenome = '" + sobrenome + "'" +
                            ", CPF = '" + cpf + "'" +
                            ", RG = '" + rg + "'" +
                            ", Email = '" + email + "'" +
                            //", UsuEst = '" + status + "'" +
                            ", Genero = '" + genero + "'" +
                            ", Endereco = '" + endereco + "'" +
                            ", CEP = '" + cep + "'" +
                            ", Telefone = '" + telefone + "'" +
                            ", Celular = '" + celular + "'" +
                            ", DataNascimento = '" + dataNascimento + "'" +
                            ", DataUltimaModificacao = '" + dataUltimaModificacao + "'" +
                            ", PerfilFacebook = '" + linkFace + "'" +
                            ", PerfilInstagram = '" + linkInstagram + "'" +
                            ", PerfilLinkedIn = '" + linkLinkedIn + "'" +
                            ", Sobre = '" + sobre + "'" +
                            //", Portfolio = '" + site + "'" +
                            ", Site = '" + site + "'" +
                            " WHERE Login = '" + login + "'";

            SqlConnection conn = new SqlConnection(conexao);
            try
            {
                conn.Open();
                SqlCommand comando = new SqlCommand(sql, conn); //executa o comando passado por parâmetro junto com a conexão

                //comando.ExecuteNonQuery(); //executa comando conforme os parâmetros
                int rowsAffected = comando.ExecuteNonQuery();

                result = rowsAffected.ToString();

            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        //
        /// <summary>
        /// Verifica se o usuário já possui imagem de perfil cadastrada
        /// </summary>
        /// <param name="login">Recebe por parâmetro o Login digitado na tela</param>
        /// <returns></returns>
        public string obtemFotoPerfilUsuario(string login)
        {
            DateTime dataUltimaModificacao = DateTime.Now;
            string result = ""; //variavel de retorno

            //string sql = "select TipoUsuario from dbo.tblUsuarios where Login = '" + login + "' and Senha = '" + senha + "'";
            string sql = "SET DATEFORMAT dmy " + //define o formato da data a ser inserida no banco
                            "SELECT ImagemPerfil FROM Usuarios " +
                               //" SET ImagemPerfil = '" + ImagemPerfil + "'" +
                               //", DataUltimaModificacao = '" + dataUltimaModificacao + "'" +
                            " WHERE Login = '" + login + "'";

            SqlConnection conn = new SqlConnection(conexao);
            try
            {
                conn.Open();
                SqlCommand comando = new SqlCommand(sql, conn); //executa o comando passado por parâmetro junto com a conexão

                //comando.ExecuteNonQuery(); //executa comando conforme os parâmetros
                //int rowsAffected = comando.ExecuteNonQuery();

                result = (string)comando.ExecuteScalar();
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// Atualiza imagem de usuário já cadastrado na base
        /// </summary>
        /// <param name="login">Recebe por parâmetro o Login digitado na tela</param>
        /// <param name="ImagemPerfil">Recebe por parâmetro a imagem selecionada na tela</param>
        /// <returns></returns>
        public string atualizaFotoPerfilUsuario(string login, string ImagemPerfil)
        {
            DateTime dataUltimaModificacao = DateTime.Now;
            string result = ""; //variavel de retorno

            //string sql = "select TipoUsuario from dbo.tblUsuarios where Login = '" + login + "' and Senha = '" + senha + "'";
            string sql = "SET DATEFORMAT dmy " + //define o formato da data a ser inserida no banco
                            "UPDATE Usuarios " +
                               " SET ImagemPerfil = '" + ImagemPerfil + "'" +
                               ", DataUltimaModificacao = '" + dataUltimaModificacao + "'" +
                            " WHERE Login = '" + login + "'";

            SqlConnection conn = new SqlConnection(conexao);
            try
            {
                conn.Open();
                SqlCommand comando = new SqlCommand(sql, conn); //executa o comando passado por parâmetro junto com a conexão

                //comando.ExecuteNonQuery(); //executa comando conforme os parâmetros
                int rowsAffected = comando.ExecuteNonQuery();

                result = rowsAffected.ToString();
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// Verifica se o Login inserido na tela de registro já está cadastrado para outro usuário
        /// </summary>
        /// <param name="login">Recebe por parâmetro o Login digitado na tela</param>
        /// <returns>Retorna uma string de resultado da consulta na base de dados</returns>
        public string verificaLogin(string login)
        {
            string result = ""; //variavel de retorno

            //string vrfLogin = "select Login from dbo.tblUsuarios where Login = '" + login + "'";
            string vrfLogin = "select count(*) as countLogin from dbo.Usuarios where Login = '" + login + "'";
            SqlConnection conn = new SqlConnection(conexao);
            try
            {
                conn.Open();
                SqlCommand comando = new SqlCommand(vrfLogin, conn); //executa o comando passado por parâmetro junto com a conexão
                SqlDataReader dr = comando.ExecuteReader();  //armazena o retorno obtido no objeto passado por parâmetro
                if (dr.Read()) //lê o retorno obtido
                {
                    result = dr["countLogin"].ToString();  //converte p/ string o alias definido no filtro da consulta ao banco
                }
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        /// <summary>
        /// Verifica se o CPF inserido na tela de registro já está cadastrado para outro usuário
        /// </summary>
        /// <param name="cpf">Recebe por parâmetro o E-mail digitado na tela</param>
        /// <returns>Retorna uma string de resultado da consulta na base de dados</returns>
        public string verificaCpf(string cpf)
        {
            string result = ""; //variavel de retorno

            //valida email
            string vrfCpf = "select count(*) as countCpf from dbo.Usuarios where CPF = '" + cpf + "'";
            SqlConnection conn = new SqlConnection(conexao);
            try
            {
                conn.Open();
                SqlCommand comando = new SqlCommand(vrfCpf, conn); //executa o comando passado por parâmetro junto com a conexão
                SqlDataReader dr = comando.ExecuteReader();  //armazena o retorno obtido no objeto passado por parâmetro
                if (dr.Read()) //lê o retorno obtido
                {
                    result = dr["countCpf"].ToString();  //converte p/ string o alias definido no filtro da consulta ao banco
                }
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        /// <summary>
        /// Verifica se o Email inserido na tela de registro já está cadastrado para outro usuário
        /// </summary>
        /// <param name="email">Recebe por parâmetro o E-mail digitado na tela</param>
        /// <returns>Retorna uma string de resultado da consulta na base de dados</returns>
        public string verificaEmail(string email)
        {
            string result = ""; //variavel de retorno

            //valida cpf
            string vrfEmail = "select count(*) as countEmail from dbo.Usuarios where Email = '" + email + "'";
            SqlConnection conn = new SqlConnection(conexao);
            try
            {
                conn.Open();
                SqlCommand comando = new SqlCommand(vrfEmail, conn); //executa o comando passado por parâmetro junto com a conexão
                SqlDataReader dr = comando.ExecuteReader();  //armazena o retorno obtido no objeto passado por parâmetro
                if (dr.Read()) //lê o retorno obtido
                {
                    result = dr["countEmail"].ToString();  //converte p/ string o alias definido no filtro da consulta ao banco
                }
            }
            finally
            {
                conn.Close();
            }

            return result;
        }



    }
}