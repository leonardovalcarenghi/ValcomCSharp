using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Valcom
{
    /// <summary>
    /// Métodos relacionados ao certificado digital.
    /// </summary>
    public class Certificate
    {

        #region FullName

        /// <summary>
        /// Buscar nome completo do usuário no certificado.
        /// </summary>
        /// <param name="value">Certificado X509</param>
        /// <returns>Nome completo</returns>
        public static string FullName(X509Certificate2 value)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception Ex) { throw Ex; }
        }

        public static void FullName(X509Certificate2 value, ref string fullName) => fullName = FullName(value);

        #endregion


        #region FirstName
        /// <summary>
        /// Buscar primeiro nome do usuário no certificado.
        /// </summary>
        /// <param name="value">Certificado X509</param>
        /// <returns></returns>
        public static string FirstName(X509Certificate2 value)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception Ex) { throw Ex; }
        }

        public static void FirstName(X509Certificate2 value, ref string name) => name = FirstName(value);

        #endregion


        #region LastName

        /// <summary>
        /// Buscar sobrenome do usuário no certificado.
        /// </summary>
        /// <param name="value">Certificado X509</param>
        /// <returns></returns>
        public static string LastName(X509Certificate2 value)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception Ex) { throw Ex; }
        }

        public static void LastName(X509Certificate2 value, ref string lastName) => lastName = LastName(value);

        #endregion


        #region Email

        /// <summary>
        /// Buscar e-mail do usuário no certificado.
        /// </summary>
        /// <param name="value">Certificado X509</param>
        /// <returns></returns>
        public static string Email(X509Certificate2 value)
        {
            try
            {
                foreach (X509Extension x in value.Extensions)
                {
                    if (x.Oid.Value == "2.5.29.17" || x.Oid.Value == "2.5.29.7")//"Nome Alternativo Para o Requerente") 
                    {
                        string Oid = x.Format(true);
                        if (Oid.Contains("Nome RFC822="))
                        {
                            string email = Oid.Substring(Oid.IndexOf("Nome RFC822=") + "Nome RFC822=".Length);
                            if (email.Contains("\r\nOutro Nome"))
                            {
                                email = email.Substring(0, email.IndexOf("\r\nOutro Nome"));
                                email = email.ToUpper();
                                return email;
                            }
                            else
                            {
                                email = email.ToUpper();
                                return email;
                            }
                        }
                    }
                }
                throw new Exception("Não fo encontrado o e-mail.");
            }
            catch (Exception Ex) { throw Ex; }
        }


        public static void Email(X509Certificate2 value, ref string email) => email = Email(value);

        #endregion


        #region Birthday


        /// <summary>
        /// Buscar data de nascimento do usuário no certificado.
        /// </summary>
        /// <param name="value">Certificado X509</param>
        /// <returns></returns>
        public static DateTime Birthday(X509Certificate2 value)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception Ex) { throw Ex; }
        }

        public static void Birthday(X509Certificate2 value, ref DateTime birthday) => birthday = Birthday(value);


        #endregion


        #region CPF


        /// <summary>
        /// Buscar CPF ou CNPJ do usuário no certificado.
        /// </summary>
        /// <param name="value">Certificado X509</param>
        /// <returns></returns>
        public static string CPF(X509Certificate2 value)
        {
            try
            {
                string cpf = string.Empty;
                foreach (X509Extension x in value.Extensions)
                {
                    if (x.Oid.Value == "2.5.29.17" || x.Oid.Value == "2.5.29.7")//"Nome Alternativo Para o Requerente") 
                    {
                        string Oid = x.Format(true);
                        //CNPJ
                        if (Oid.Contains("2.16.76.1.3.3"))
                        {
                            cpf = Oid.Substring(Oid.IndexOf("2.16.76.1.3.3=") + "2.16.76.1.3.3=".Length + 5, 42).Replace(" 3", "").Replace(" ", "");
                            return cpf;
                        }
                        else if (Oid.ToUpper().Contains("CNPJ="))
                        {
                            cpf = Oid.Substring(Oid.ToUpper().IndexOf("CNPJ=") + "CNPJ=".Length + 5, 42).Replace(" 3", "").Replace(" ", "");
                            return cpf;
                        }
                        //CPF
                        else if (Oid.Contains("2.16.76.1.3.1"))
                        {
                            cpf = Oid.Substring(Oid.IndexOf("2.16.76.1.3.1=") + "2.16.76.1.3.1=".Length + 31, 33).Replace(" 3", "").Replace(" ", "");
                            return cpf;
                        }
                        else if (Oid.ToUpper().Contains("ICP-BRASIL PESSOA FISICA="))
                        {
                            cpf = Oid.Substring(Oid.ToUpper().IndexOf("ICP-BRASIL PESSOA FISICA=") + "ICP-BRASIL PESSOA FISICA=".Length + 31, 33).Replace(" 3", "").Replace(" ", "");
                            return cpf;
                        }
                    }
                }
                throw new Exception("O sistema não localizou as OIDs previstas pelo ITI (2.5.29.17 ou 2.5.29.7 para Nome Alternativo Para o Requerente, 2.16.76.1.3.3 para CNPJ e 2.16.76.1.3.1 para CPF)");

            }
            catch (Exception Ex) { throw Ex; }
        }


        public static void CPF(X509Certificate2 value, ref string cpf) => cpf = CPF(value);

        #endregion

        /// <summary>
        /// Buscar emissor do certificado.
        /// </summary>
        /// <param name="value">Certificado X509</param>
        /// <returns></returns>
        public static string Inssuer(X509Certificate2 value)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception Ex) { throw Ex; }
        }

        /// <summary>
        /// Buscar identificador (thumbprint) do certificado.
        /// </summary>
        /// <param name="value">Certificado X509</param>
        /// <returns></returns>
        public static string Thumbprint(X509Certificate2 value)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception Ex) { throw Ex; }
        }

        public static string PrimaryKey(X509Certificate2 value)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception Ex) { throw Ex; }
        }

        /// <summary>
        /// Buscar data em que o certificado entra em vigência.
        /// </summary>
        /// <param name="value">Certificado X509</param>
        /// <returns></returns>
        public static DateTime NotBefore(X509Certificate2 value)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception Ex) { throw Ex; }
        }

        /// <summary>
        /// Buscar data de vencimento do certificado.
        /// </summary>
        /// <param name="value">Certificado X509</param>
        /// <returns></returns>
        public static DateTime NotAfter(X509Certificate2 value)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception Ex) { throw Ex; }
        }

        /// <summary>
        /// Verificar se o certificado está no padrão ICP Brasil.
        /// </summary>
        /// <param name="value">Certificado X509</param>
        /// <returns>True = É ICP / False = Não é ICP</returns>
        public static bool IsICP(X509Certificate2 value)
        {
            try
            {
                if (value.Verify())
                {
                    X509Chain ch = new X509Chain();

                    if (ch.Build(value))
                    {
                        if (ch.ChainElements != null && ch.ChainElements.Count > 0)
                        {
                            List<X509ChainElement> lista = new List<X509ChainElement>(ch.ChainElements.Cast<X509ChainElement>());

                            if (lista != null)
                            {
                                // Autoridade Certificadora Raiz Brasileira
                                X509ChainElement ACRB = lista.Where(c => c.Certificate.Thumbprint.ToLower() == "a9822e6c6933c63c148c2dcaa44a5cf1aad2c42e"
                                    || c.Certificate.Thumbprint.ToLower() == " ‎705d2b4565c7047a540694a79af7abb842bdc161"
                                    || c.Certificate.Thumbprint.ToLower() == "65705addff0812cf83d8cc231d555fdc06ac6560"
                                    || c.Certificate.Thumbprint.ToLower() == "4acadab14b74bf4fba7bace64b91801c44b8cc66").FirstOrDefault();


                                //if (ACRB != null && ACSRFB != null)
                                if (ACRB != null)
                                {
                                    //if (ACRB.Certificate.Verify() && ACSRFB.Certificate.Verify())
                                    if (ACRB.Certificate.Verify())
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
                return false;
            }
            catch (Exception Ex) { throw Ex; }
        }

    }

}
