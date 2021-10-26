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
    public class RepoDatHistoModel : PageModel
    {
        
        [BindProperty]
        public Estacion estacion {get;set;}

        [BindProperty]
        public Persona tecnico {get;set;}

        [BindProperty]
        public Reporte reporte {get;set;}

        [TempData]
        public string identec{get;set;}
        
        [TempData]
        public string codigoestacion{get;set;}

        [BindProperty]
        public DataMeteorologica datos{get;set;}
        public IRepositorioPersona _repoTecnico=new RepositorioPersona(new EstacionesMetereologicas.App.Persistencia.AppContext());
        public static IRepositorioEstacion _repoEstacion=new RepositorioEstacion(new EstacionesMetereologicas.App.Persistencia.AppContext());        
        public IRepositorioReporte _repoReporte=new RepositorioReporte(new EstacionesMetereologicas.App.Persistencia.AppContext());

        public IRepositorioDataMeteorologica _repoDataMeteorologica= new RepositorioDataMeteorologica(new EstacionesMetereologicas.App.Persistencia.AppContext());

        public void OnGet(string Id)
        {
            //codigoestacion="";
            codigoestacion=Id;
            datos = _repoDataMeteorologica.GetDataMeteorologica(codigoestacion);
        }

        public void OnPost()
        {

        }
        /*public IActionResult OnPostConsultarEstacion()
        {   
           string url="";
           estacion=_repoEstacion.GetEstacion(Id);
           if(estacion!=null)
           {
               codigoestacion=estacion.Codigo_Estacion;
               url="ElimRep";
           }
           else
           {
                codigoestacion="";
                url="";
           }
           return RedirectToPage(url);
        }*/

        /*public IActionResult OnPostConsultarDataMeteorologica()
        {
            datos = _repoDataMeteorologica.GetDataMeteorologica(codigoestacion);

            return Page(); 
        }*/

        /*
        public IActionResult OnPostConsultarTecnico()
        {   
           string url="";
           tecnico=_repoTecnico.GetPersona(tecnico.Identificacion);
           if(tecnico!=null)
           {
               identec=tecnico.Identificacion;
               url="ReporteTecnico";
           }
           else
           {
                identec="";
                url="";
           }
           return RedirectToPage(url);
        }

        /*[BindProperty]
        public Reporte reporte{ get; set;}
        public IRepositorioReporte _repoReporte=new RepositorioReporte(new EstacionesMetereologicas.App.Persistencia.AppContext());

        public IActionResult OnGet(int Id)
        {
           reporte = _repoReporte.GetReporteId(Id);
           if (reporte == null)
           {
             return RedirectToPage("../Error");
           }
           else
           return Page();
        }         

        public void OnPostEliminar(int Id)
        {
          _repoReporte.DeleteReporteId(Id);
        }*/
    }
}
