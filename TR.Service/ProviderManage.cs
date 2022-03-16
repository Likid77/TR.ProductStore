using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.Domain;

namespace TR.Service
{
    public class ProviderManage
    {
        // Properties
        // ==========
        public IList<Provider> Providers { get; set; } = new List<Provider>();


        // Methods
        //        13. Ajouter dans la classe ProviderManager les méthodes suivantes :
        //c.GetProviderByName(string name) : retourne la liste des providers dont le nom contient name.
        public void GetProviderByName(string name)
        { var query = Providers.Where(p => p.UserName.Contains(name)); }

        //d.GetFirstProviderByName(string name) : retourne le premier provider dont le nom commence par name.
        public void GetFirstProviderByName(string name)
        { var query = Providers.Where(p => p.UserName.Contains(name)).FirstOrDefault(); }

        //e.GetProviderById(int id) : retourne le provider d’identifiant id.
        //public void GetFirstProviderById(int id)
        //{ var query = Providers.OrderBy(id).FirstOrDefault(); }

    }
}
