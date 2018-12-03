using System;
using Entities;
using BusinessLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoMedico
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }
        static async Task MainAsync()
        {
        // INICIO DE PROGRAMA
        
            // INSTANCIAMOS CLASES DE LA CAPA DE ENTIDADES

            // INSTANCIAMOS CLASES DE LA CAPA DE NEGOCIOS
            HistoriaClinicaBL Historias = new HistoriaClinicaBL();
            //EspecialidadBL especialidades = new EspecialidadBL();
            PacienteBL Pacientes = new PacienteBL();
            MedicoBL Medicos = new MedicoBL();
            string mensaje = "";

            await MenuPrincipal();

            // MENU
            async Task MenuPrincipal()
            {
                Console.Clear();
                int selMain = 0;
                string menu = @"MENU PRINCIPAL:
                1.  Administracion de citas.
                2.  Administracion de pacientes.
                3.  Administracion de historias clinicas.
                4.  Administracion de especialidades.
                5.  Administracion de personal medico. 
                6.  Administracion de medicamentos de farmacia.
                7.  Administracion de enfermedades.
                8.  Administracion de diagnosticos.

                    Ingrese numero para elegir opcion:
                ";
                Console.WriteLine(menu);
                selMain = int.Parse(Console.ReadLine());

                if (selMain == 1) await GestionCitas();
                if (selMain == 2) await GestionPacientes();
                if (selMain == 3) await GestionHistoriasClinicas();
                if (selMain == 4) await GestionEspecialidades();
                if (selMain == 5) await GestionPersonalMedico();
                if (selMain == 6) await GestionMedicamentos();
                if (selMain == 7) await GestionEnfermedades();
                if (selMain == 8) await GestionDiagnosticos();
            }

            // Admision y generacion de cita
            async Task GestionCitas()
            {
                var citas = await Metodos.GetCitas();
                Console.Clear();
                mensaje = "";
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE CITAS");
                await Metodos.MostrarCitas();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE PACIENTES");
                await Metodos.MostrarPacientes();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE HISTORIAS CLINICAS");
                await Metodos.MostrarHistorias();
                string MenuAdmision = @"MENU CITAS:
                1.  Generar cita.
                2.  Eliminar cita.
                3.  Generar interconsulta.
                4.  Volver a menu principal.
                ";
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(mensaje);
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(MenuAdmision);
                int selMainAdm = int.Parse(Console.ReadLine());

                if (selMainAdm == 1) { await GenerarCita(); await GestionCitas(); }
                if (selMainAdm == 2) { await Metodos.EliminarCita(); await GestionCitas(); }
                //if (selMainAdm == 3) { await GenerarInterconsulta(); await GestionCitas(); }
                if (selMainAdm == 4) { await MenuPrincipal(); mensaje = ""; }
            }

            // Generar cita y codigo de cita
            async Task GenerarCita()
            {
                var pacientes = await Metodos.GetPacientes();
                var historias = await Metodos.GetHistoriasClinicas();
                var citas = await Metodos.GetCitas();
                var especialidades = await Metodos.GetEspecialidades();
                var medicos = await Metodos.GetMedicos();
                string cita = "";
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE PACIENTES");
                await Metodos.MostrarPacientes();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE HISTORIAS CLINICAS");
                await Metodos.MostrarHistorias();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE CITAS");
                await Metodos.MostrarCitas();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE ESPECIALIDADES");
                await Metodos.MostrarEspecialidades();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE MEDICOS");
                await Metodos.MostrarMedicos();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE DIAGNOSTICOS");
                await Metodos.MostrarDiagnosticos();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(mensaje);
                Console.WriteLine("----------------------------------------------------------------");

                cita = await Metodos.GenerarCita();
                if (cita.Split(":")[0] != "Error")
                {
                    mensaje = cita;
                    //string Dni = cita.Split(":")[1];
                    await GestionDiagnosticos();
                }
                mensaje = cita;
            }

            async Task GestionPacientes()
            {
                List<Paciente> pacientes = await Metodos.GetPacientes();
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE PACIENTES");
                await Metodos.MostrarPacientes();
                string MenuEspecialidades = @"MENU ESPECIALIDADES:
                1.  Crear paciente.
                2.  Actualizar paciente.
                3.  Eliminar paciente.
                4.  Volver a menu principal.
                ";
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(mensaje);
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(MenuEspecialidades);
                int selMainPac = int.Parse(Console.ReadLine());
                if (selMainPac == 1) { mensaje = await Metodos.InsertarPaciente(); await GestionPacientes(); }
                if (selMainPac == 2) { mensaje = await Metodos.ActualizarPaciente(); await GestionPacientes(); }
                if (selMainPac == 3) { mensaje = await Metodos.EliminarPaciente(); await GestionPacientes(); }
                //if (selMainPac == 4) { mensaje = await Metodos.EliminarPacientesTodos(); await GestionPacientes(); }
                if (selMainPac == 4) { await MenuPrincipal(); mensaje = ""; }
            }

            //Gestion Historias Clinicas
            async Task GestionHistoriasClinicas()
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE HISTORIAS CLINICAS");
                await Metodos.MostrarHistorias();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE PACIENTES");
                await Metodos.MostrarPacientes();
                string MenuEspecialidades = @"MENU HISTORIAS CLINICAS:
                1.  Crear historia clinica.
                2.  Actualizar historia clinica.
                3.  Eliminar historia clinica.
                4.  Volver a menu principal
                ";
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(mensaje);
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(MenuEspecialidades);
                int selMainPac = int.Parse(Console.ReadLine());
                if (selMainPac == 1) { mensaje = await Metodos.InsertarHistoriaClinica(); await GestionHistoriasClinicas(); }
                if (selMainPac == 2) { mensaje = await Metodos.UpdateHistoriaClinica(); await GestionHistoriasClinicas(); }
                if (selMainPac == 3) { mensaje = await Metodos.EliminarHistoriaClinica(); await GestionHistoriasClinicas(); }
                if (selMainPac == 4) { await MenuPrincipal(); mensaje = ""; }
            }
            
            // Gestion de especialidades
            async Task GestionEspecialidades()
            {
                List<Especialidad> especialidades = await Metodos.GetEspecialidades();
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE ESPECIALIDADES");
                await Metodos.MostrarEspecialidades();
                string MenuEspecialidades = @"MENU ESPECIALIDADES:
                1.  Generar especialidad.
                2.  Actualizar especialidad.
                3.  Eliminar especialidad.
                4.  Volver a menu principal.
                ";
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(mensaje);
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(MenuEspecialidades);
                int selMainEsp = int.Parse(Console.ReadLine());
                if (selMainEsp == 1) { mensaje = await Metodos.InsertarEspecialidad(); await GestionEspecialidades(); }
                if (selMainEsp == 2) { mensaje = await Metodos.UpdateEspecialidad(); await GestionEspecialidades(); }
                if (selMainEsp == 3) { mensaje = await Metodos.DeleteEspecialidad(); await GestionEspecialidades(); }
                if (selMainEsp == 4) { await MenuPrincipal(); mensaje = ""; }
            }

            async Task GestionPersonalMedico()
            {
                var medicos = await Metodos.GetMedicos();
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE MEDICOS");
                await Metodos.MostrarMedicos();
                string MenuEspecialidades = @"MENU MEDICOS:
                1.  Crear Medico.
                2.  Actualizar Medico.
                3.  Eliminar Medico.
                4.  Volver a menu principal.
                ";
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(mensaje);
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(MenuEspecialidades);
                int selMainMed = int.Parse(Console.ReadLine());
                if (selMainMed == 1) { mensaje = await Metodos.InsertarMedico(); await GestionPersonalMedico(); }
                if (selMainMed == 2) { mensaje = await Metodos.ActualizarMedico(); await GestionPersonalMedico(); }
                if (selMainMed == 3) { mensaje = await Metodos.EliminarMedico(); await GestionPersonalMedico(); }
                if (selMainMed == 4) { await MenuPrincipal(); mensaje = ""; }
            }

            // Diagnostico y receta de medicamentos
            async Task GestionMedicamentos()
            {
                //Console.Clear();
                mensaje = "";
                string MenuMedicamentos = @"MENU MEDICAMENTOS:
                1.  Insertar Medicamento.
                2.  Actualizar Medicamento.
                3.  Eliminar Medicamento.
                4.  Mostrar Medicamentos.
                5.  Volver a menu principal.
                ";
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(mensaje);
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(MenuMedicamentos);
                int selMainMed = int.Parse(Console.ReadLine());
                if (selMainMed == 1) { mensaje = await Metodos.InsertarMedicamento(); await GestionMedicamentos(); }
                if (selMainMed == 2) { mensaje = await Metodos.UpdateMedicamento(); await GestionMedicamentos(); }
                if (selMainMed == 3) { mensaje = await Metodos.EliminarMedicamento(); await GestionMedicamentos(); }
                if (selMainMed == 4) { await Metodos.MostrarMedicamentos(); await GestionMedicamentos(); }
                if (selMainMed == 5) { await MenuPrincipal(); mensaje = ""; }
            }

            // Diagnostico y receta de enfermedades
            async Task GestionEnfermedades()
            {
                Console.Clear();
                string MenuEnfermedades = @"SISTEMA HOSPITALARIO:
                1.  Registrar Enfermedad.
                2.  Actualizar Enfermedad.
                3.  Eliminar Enfermedad.
                4.  Mostrar Enfermedad.
                5.  Volver a menu principal.
                ";
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(mensaje);
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(MenuEnfermedades);
                int selMainEnf = int.Parse(Console.ReadLine());
                if (selMainEnf == 1) { mensaje = await Metodos.InsertarEnfermedad(); await GestionEnfermedades(); }
                if (selMainEnf == 2) { mensaje = await Metodos.ActualizarEnfermedad(); await GestionEnfermedades(); }
                if (selMainEnf == 3) { mensaje = await Metodos.EliminarEnfermedad(); await GestionEnfermedades(); }
                if (selMainEnf == 4) { await Metodos.MostrarEnfermedades(); await GestionEnfermedades(); }
                if (selMainEnf == 5) { await MenuPrincipal(); mensaje = ""; }
            }

            // Gestion de diagnosticos
            async Task GestionDiagnosticos()
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE DIAGNOSTICOS");
                await Metodos.MostrarDiagnosticos();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE CITAS");
                await Metodos.MostrarCitas();
                string MenuDiagnosticos = @"MENU DIAGNOSTICOS:
                1.  Registrar Diagnostico.
                2.  Actualizar Diagnostico.
                3.  Eliminar Diagnostico.
                4.  Mostrar Diagnosticos.
                5.  Volver a menu principal.
                ";
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(mensaje);
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(MenuDiagnosticos);
                int selMainDiag = int.Parse(Console.ReadLine());
                if (selMainDiag == 1) { mensaje = await Metodos.InsertarDiagnostico(); await GestionDiagnosticos(); }
                if (selMainDiag == 2) { mensaje = await Metodos.UpdateDiagnostico(); await GestionDiagnosticos(); }
                if (selMainDiag == 3) { mensaje = await Metodos.DeleteDiagnostico(); await GestionDiagnosticos(); }
                if (selMainDiag == 4) { mensaje = await Metodos.MostrarDiagnosticos(); await GestionDiagnosticos(); }
                if (selMainDiag == 5) { await MenuPrincipal(); mensaje = ""; }
            }

        }

        // METODOS
    }
}
