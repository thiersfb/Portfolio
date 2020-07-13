using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dados
{
    public class Usuario
    {
        private static string User_Login = "";
        private static string User_Senha = "";
        //private static string User_Tipo = "";
        private static string User_Nome = "";
        private static string User_Sobrenome = "";
        private static string User_CPF = "";
        private static string User_RG = "";
        private static string User_Email = "";
        private static string User_Status = "";
        private static string User_Endereco = "";
        private static string User_CEP = "";
        private static string User_Telefone = "";
        private static string User_Celular = "";
        private static string User_Genero = "";
        private static string User_Site = "";
        private static string User_PerfilFacebook = "";
        private static string User_PerfilInstagram = "";
        private static string User_PerfilLinkedIn = "";
        private static string User_Sobre = "";
        private static string User_ImagemPerfil = "";

        //getters & setters
        public static string userLogin
        {
            get { return User_Login; }
            set { User_Login = value; }
        }
        public static string userSenha
        {
            get { return User_Senha; }
            set { User_Senha = value; }
        }
        //public static string userTipo
        //{
        //    get { return User_Tipo; }
        //    set { User_Tipo = value; }
        //}
        public static string userNome
        {
            get { return User_Nome; }
            set { User_Nome = value; }
        }
        public static string userSobrenome
        {
            get { return User_Sobrenome; }
            set { User_Sobrenome = value; }
        }
        public static string userCPF
        {
            get { return User_CPF; }
            set { User_CPF = value; }
        }
        public static string userRG
        {
            get { return User_RG; }
            set { User_RG = value; }
        }
        public static string userEmail
        {
            get { return User_Email; }
            set { User_Email = value; }
        }
        public static string userStatus
        {
            get { return User_Status; }
            set { User_Status = value; }
        }
        public static string userEndereco
        {
            get { return User_Endereco; }
            set { User_Endereco = value; }
        }
        public static string userCEP
        {
            get { return User_CEP; }
            set { User_CEP = value; }
        }
        public static string userTelefone
        {
            get { return User_Telefone; }
            set { User_Telefone = value; }
        }
        public static string userCelular
        {
            get { return User_Celular; }
            set { User_Celular = value; }
        }
        public static string userGenero
        {
            get { return User_Genero; }
            set { User_Genero = value; }
        }
        public static string userSite
        {
            get { return User_Site; }
            set { User_Site = value; }
        }
        public static string userPerfilFacebook
        {
            get { return User_PerfilFacebook; }
            set { User_PerfilFacebook = value; }
        }
        public static string userPerfilInstagram
        {
            get { return User_PerfilInstagram; }
            set { User_PerfilInstagram = value; }
        }
        public static string userPerfilLinkedIn
        {
            get { return User_PerfilLinkedIn; }
            set { User_PerfilLinkedIn = value; }
        }
        public static string userSobre
        {
            get { return User_Sobre; }
            set { User_Sobre = value; }
        }
        public static string userImagemPerfil
        {
            get { return User_ImagemPerfil; }
            set { User_ImagemPerfil = value; }
        }
    }
}