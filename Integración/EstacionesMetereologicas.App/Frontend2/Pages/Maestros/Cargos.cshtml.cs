using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EstacionesMetereologicas.App.Persistencia;
using EstacionesMetereologicas.App.Dominio;

namespace FrontEnd2.Pages
{
    public class CargosModel : PageModel
    {
        public IRepositorioCargo _repoCargo=new RepositorioCargo(new EstacionesMetereologicas.App.Persistencia.AppContext());
        public IEnumerable<Cargo> cargo{ get; set; }
        public void OnGet()
        {
            cargo = _repoCargo.GetAllCargos();
        }
    }
}
