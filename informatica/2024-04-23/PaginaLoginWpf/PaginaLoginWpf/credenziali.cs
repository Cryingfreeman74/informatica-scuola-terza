using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Security.Cryptography;
using System.IO.Pipes;
using System.Runtime.Intrinsics.Arm;

namespace PaginaLoginWpf
{
    class Utente
    {
        public string Nome { get; }
        public string Cognome { get; }
        public string Username { get; }
        public string Password { get; }
        public Utente(string Nome, string Cognome, string Username, string Password)
        {
                this.Nome = Nome;
                this.Cognome = Cognome;
                this.Username = Username;
                this.Password = Password; //must be hashed!
        }

        public void addUserToFile(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine("{0}#{1}#{2}#{3}", Nome, Cognome, Username, Password);
            }
        }
    }
    class Credenziali
    {
        /// <summary>
        /// Contiene tutti gli utenti registrati con chiave = Username e value = Utente
        /// </summary>
        private Dictionary<string, Utente> Utenti = new Dictionary<string, Utente>();

        /// <summary>
        /// Archivio contenente tutti i dati degli utenti salvati
        /// </summary>
        private string datiUtentiRegistrati = "";

        /// <summary>
        /// Costruttore della classe
        /// </summary>
        /// <param name="filePath">Path dell'archivio</param>
        public Credenziali(string filePath)
        {
            datiUtentiRegistrati = filePath;
            bool fileVuoto = false;
            using (StreamReader sr = new StreamReader(datiUtentiRegistrati))
            {
                if (sr.EndOfStream)                                                         //file vuoto
                    fileVuoto = true;
                else if (sr.ReadLine() != "ARCHIVIO UTENTI CREATO DA BALDUCCI MARCO >:3")   //file non vuoto contenente altri dati
                    throw new Exception("File non valido.");
                else                                                                        //file contiene già dati di Utenti
                    Utenti = LoadFromFile();
            }
            if(fileVuoto)
            {
                using (StreamWriter sw = new StreamWriter(datiUtentiRegistrati))
                    sw.WriteLine("ARCHIVIO UTENTI CREATO DA BALDUCCI MARCO >:3");
            }
        }
        Dictionary<string, Utente> LoadFromFile() 
        {
            Dictionary<string, Utente> dizionario = new Dictionary<string, Utente>();

            using (StreamReader sr = new StreamReader(datiUtentiRegistrati))
            {
                sr.ReadLine(); //skip della riga dell'intestazione
                int lineCounter = 0;
                while (!sr.EndOfStream)
                {
                    lineCounter++;
                    string[] line = sr.ReadLine().Split("#", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                    if (line.Length != 4) throw new Exception($"Invalid User at line {lineCounter}");

                    Utente utente = new Utente(Nome: line[0], Cognome: line[1], Username: line[2], Password: line[3]);
                    dizionario.Add(utente.Username, utente);
                }
            }

            return dizionario;
        }
        static string hashPassword(string password)
        {
            using (SHA256 SHA256 = SHA256.Create())
            {
                byte[] hashValue = SHA256.HashData(Encoding.UTF8.GetBytes(password));
                return Convert.ToHexString(hashValue);
            }
        }

        private bool IsUsernameAvailable(string username)
        {
            return !Utenti.ContainsKey(username);
        }

        private string GetHashedPassword(string username)
        {
            if (IsUsernameAvailable(username)) throw new Exception("Utente non ancora registrato.");

            return Utenti[username].Password;
        }

        public void Register(string nome, string cognome, string username, string password)
        {
            if (IsUsernameAvailable(username))
            {
                Utente utente = new Utente(nome, cognome, username, hashPassword(password));
                utente.addUserToFile(datiUtentiRegistrati);
                Utenti.Add(username, utente);
            }
            else throw new Exception("Username già presente.");
        }
        
        public bool AutenticaUtente(string username, string password) 
        { 
            return GetHashedPassword(username) == hashPassword(password);
        }

        public bool EliminaUtente(string username, string password)
        {
            if (GetHashedPassword(username) == hashPassword(password))
            { 
                Utenti.Remove(username);
                return true;
            } else return false;
        }
    }
}
