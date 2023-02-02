using System;
using System.Collections.Generic;

namespace Projet2.Models
{
	public interface IDal : IDisposable
	{
        void DeleteCreateDatabase();
        List<Utilisateur> GetUsersList();
        int CreateUser(int idCompte, int IdInfosPersonnelles);
        int CreateUser(Utilisateur utilisateur);
        int ModifyUser(Utilisateur utilisateur);
        void ModifyUser(int id);
        void RemoveUser(Utilisateur utilisateur);

        List<Club> GetClubsList();
        int CreateClub(Club club);
        void ModifyClub(int id);
        void RemoveClub(Club club);

    }
}

