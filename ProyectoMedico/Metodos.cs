using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BusinessLayer;
using System.Threading.Tasks;

namespace Entities
{
    public static class Metodos
    {
        // METODOS DE ADMINISTRACION DE PACIENTES
        public static async Task<List<Paciente>> GetPacientes()
        {
            PacienteBL bl = new PacienteBL();
            return await bl.GetPacientesAsync();
        }
        public static async Task<Paciente> BuscarPaciente(string dni)
        {
            PacienteBL bl = new PacienteBL();
            return await bl.BuscarPacienteAsync(dni);
        }
        public static async Task<string> ActualizarPaciente()
        {
            var paciente = new Paciente();
            Console.WriteLine("Ingrese Dni:");
            string Dni = Console.ReadLine();
            if (Dni.Length != 8)
            {
                return "Numero de digitos invalidos para Dni";
            }
            var bl = new PacienteBL();
            //await MostrarPacientes();
            if (!await ValidarPaciente(Dni))
            {
                return "Ingrese Dni de paciente valido";
            }
            paciente = await BuscarPaciente(Dni);
            Console.WriteLine("¿Qué desea modificar?");
            string opcionesPac = @"
            1) Nombre.
            2) Apellido.
            3) Fecha de nacimiento.
            4) Tipo de seguro.
            5) Estado de cuenta de paciente.
            6) Ninguno.";
            Console.WriteLine(opcionesPac);
            int opcionesIn = int.Parse(Console.ReadLine());
            if (opcionesIn == 1) goto PacNombre;
            if (opcionesIn == 2) goto PacApellido;
            if (opcionesIn == 3) goto PacFecha;
            if (opcionesIn == 4) goto PacTipo;
            if (opcionesIn == 5) goto PacEstado;
            if (opcionesIn == 6) return "No se hizo cambios";
            paciente.Dni = Dni;
        PacNombre:
            Console.WriteLine("Ingrese nuevo Nombre: ");
            paciente.Nombre = Console.ReadLine();
            goto PacSalida;
        PacApellido:
            Console.WriteLine("Ingrese nuevo Apellido: ");
            paciente.Apellido = Console.ReadLine();
            goto PacSalida;
        PacFecha:
            Console.WriteLine("Ingrese nueva Fecha de nacimiento (YYYY/MM/DD): ");
            paciente.FechaNacimiento = Console.ReadLine();
            goto PacSalida;
        PacTipo:
            Console.WriteLine("Ingrese nuevo Tipo de seguro (Asegurado/Particular): ");
            paciente.TipoSeguro = Console.ReadLine();
            goto PacSalida;
        PacEstado:
            Console.WriteLine("Ingrese nuevo Tipo de Estado de cuenta de paciente (Activo/Inactivo): ");
            paciente.EstadoPaciente = Console.ReadLine();
        PacSalida:
            await bl.ActualizarPacienteAsync(paciente);
            return "Actualizacion de paciente exitoso";
        }
        public static async Task<string> InsertarPaciente()
        {
            Console.WriteLine("Ingrese Dni:");
            string Dni = Console.ReadLine();
            if (Dni.Length != 8)
            {
                return "Numerode digitos invalidos para Dni";
            }
            if (await ValidarPaciente(Dni)) { return "Paciente encontrado, ingrese otro Dni"; }
            Paciente paciente = new Paciente();
            PacienteBL bl = new PacienteBL();
            paciente.Dni = Dni;
            Console.WriteLine("Ingrese Nombre: ");
            paciente.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Apellido: ");
            paciente.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese Fecha de nacimiento (YYYY/MM/DD): ");
            paciente.FechaNacimiento = Console.ReadLine();
            Console.WriteLine("Ingrese Tipo de seguro (Interconsulta/Normal): ");
            paciente.TipoSeguro = Console.ReadLine();
            Console.WriteLine("Ingrese Estado de paciente (Activo/Inactivo/Eliminado): ");
            paciente.EstadoPaciente = Console.ReadLine();
            //var historia = await BuscarHistoriaClinica(Dni);
            //paciente.IdHistoria = historia.IdHistoria;

            if (await bl.InsertarPacienteAsync(paciente) != 0)
            {
                return "Paciente creado exitosamente";
            }
            else { return "Error: Registro frustrado"; }
        }
        public static async Task<int> InsertarPaciente(string Dni)
        {
            Paciente paciente = new Paciente();
            PacienteBL bl = new PacienteBL();
            paciente.Dni = Dni;
            Console.WriteLine("Ingrese Nombre: ");
            paciente.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Apellido: ");
            paciente.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese Fecha de nacimiento (YYYY/MM/DD): ");
            paciente.FechaNacimiento = Console.ReadLine();
            Console.WriteLine("Ingrese Tipo (Interconsulta/Normal): ");
            //var historia = await BuscarHistoriaClinica(Dni);
            //paciente.IdHistoria = historia.IdHistoria;
            paciente.TipoSeguro = Console.ReadLine();
            return await bl.InsertarPacienteAsync(paciente);
        }
        public static async Task<string> EliminarPacientesTodos()
        {
            var bl = new PacienteBL();
            await bl.EliminarPacientesTodo();
            return "Proceso de eliminacion de todos los pacientes exitoso";
        }
        public static async Task<string> EliminarPaciente()
        {
            Console.WriteLine("Ingrese Dni:");
            string Dni = Console.ReadLine();
            if (Dni.Length != 8)
            {
                return "Numero de digitos invalidos para Dni";
            }
            if (!await ValidarPaciente(Dni))
            {
                return "Ingrese Dni de paciente valido";
            }
            var bl = new PacienteBL();
            Console.WriteLine(await ValidarPaciente(Dni));
            await bl.EliminarPaciente(Dni);
            return "Proceso de eliminacion de paciente exitoso";
        }
        public static async Task<int> MostrarPacientes()
        {
            var pacientes = await GetPacientes();
            foreach (var item in pacientes)
            {
                Console.WriteLine(item);
            }
            return 1;
        }
        public static async Task<bool> ValidarPaciente(string Dni)
        {
            var pacientes = await GetPacientes();
            if (validar(Dni))
                return true;
            else return false;

            bool validar(string valor)
            {
                foreach (var item in pacientes)
                {
                    if (item.Dni == valor)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        // METODOS DE ADMINISTRACION DE HISTORIAS CLINICAS
        public static async Task<List<HistoriaClinica>> GetHistoriasClinicas()
        {
            HistoriaClinicaBL bl = new HistoriaClinicaBL();
            return await bl.GetHistoriaClinicaAsync();
        }
        public static async Task<HistoriaClinica> BuscarHistoriaClinica(string Dni)
        {
            
            HistoriaClinicaBL bl = new HistoriaClinicaBL();
            return await bl.BuscarHistoriaClinicaAsync(Dni);
        }
        public static async Task<string> UpdateHistoriaClinica()
        {
            Console.WriteLine("Ingrese Dni:");
            string Dni = Console.ReadLine();
            if (Dni.Length != 8)
            {
                return "Numerode digitos invalidos para Dni";
            }
            if (!await ValidarPaciente(Dni)) { return "Paciente no encontrado con ese Dni, asegurese de registrarlo primero"; }
            HistoriaClinica historia = await BuscarHistoriaClinica(Dni);
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine(historia);
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("¿Qué desea modificar?");
            string opcionesPac = @"
            1) CodEspecialidad.
            2) Peso.
            3) Talla.
            4) Ninguno.";
            Console.WriteLine(opcionesPac);
            int opciones = int.Parse(Console.ReadLine());
            //historia.Dni = Dni;
            switch (opciones)
            {
                case 1:
                    await MostrarEspecialidades();
                    Console.WriteLine("Ingrese CodEspecialidad: ");
                    historia.CodEspecialidad = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Ingrese Peso: ");
                    historia.Peso = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Ingrese Talla: ");
                    historia.Talla = Console.ReadLine();
                    break;
                case 4:
                    return "No se hicieron cambios";
                    //break;
                default:
                    return "Ingrese una opcion correcta";
            }
        
            HistoriaClinicaBL bl = new HistoriaClinicaBL();
            if(await bl.UpdateHistoriaClinicaAsync(historia, Dni) != 0) { return "Historia actualizada con exito"; }
            return "Actualizacion de historia errada";
        }
        public static async Task<string> InsertarHistoriaClinica()
        {
            Console.WriteLine("Ingrese Dni:");
            string Dni = Console.ReadLine();
            if (Dni.Length != 8)
            {
                return "Numerode digitos invalidos para Dni";
            }
            if (!await ValidarPaciente(Dni)){  return "Paciente no encontrado con ese Dni, asegurese de registrarlo primero"; }
            var historia = new HistoriaClinica();
            var bl = new HistoriaClinicaBL();
            Console.WriteLine("Paciente encontrado");
            if (await ValidarHistoria(Dni)) { return "Paciente ya tiene historia"; }
            Console.WriteLine("Ingrese IdHistoriaClinica");
            historia.IdHistoria = Console.ReadLine();
            await MostrarEspecialidades();
            Console.WriteLine("Ingrese CodEspecialidad");
            historia.CodEspecialidad = Console.ReadLine();
            //Console.WriteLine("Ingrese Fecha de apertura");
            historia.FechaApertura = DateTime.Now;
            Console.WriteLine("Ingrese Peso");
            historia.Peso = Console.ReadLine();
            Console.WriteLine("Ingrese Talla");
            historia.Talla = Console.ReadLine();
            //Console.WriteLine("Ingrese Dni");
            historia.Dni = Dni;
            if(await bl.InsertarHistoriaClinicaAsync(historia) !=0) { return "Historia creada"; }
            else { return "Generación de historia fallida"; }
        }
        public static async Task<int> InsertarHistoriaClinica(string Dni)
        {
            //var paciente = await BuscarPaciente(Dni);
            var historia = new HistoriaClinica();
            //historia.Dni = paciente.Dni;

            Console.WriteLine("Ingrese IdHistoriaClinica");
            historia.IdHistoria = Console.ReadLine();
            await MostrarEspecialidades();
            Console.WriteLine("Ingrese CodEspecialidad");
            historia.CodEspecialidad = Console.ReadLine();
            //Console.WriteLine("Ingrese Fecha de apertura");
            historia.FechaApertura = DateTime.Now;
            Console.WriteLine("Ingrese Peso");
            historia.Peso = Console.ReadLine();
            Console.WriteLine("Ingrese Talla");
            historia.Talla = Console.ReadLine();
            //Console.WriteLine("Ingrese Dni");
            historia.Dni = Dni;

            var bl = new HistoriaClinicaBL();
            return await bl.InsertarHistoriaClinicaAsync(historia);
        }
        public static async Task<string> EliminarHistoriaClinica()
        {
            Console.WriteLine("Ingrese Dni:");
            string Dni = Console.ReadLine();
            if (Dni.Length != 8)
            {
                return "Numero de digitos invalido";
            }
            if (!await ValidarPaciente(Dni)) { return "Paciente no encontrado con ese Dni, asegurese de registrarlo primero"; }
            var bl = new HistoriaClinicaBL();
            if (await bl.EliminarHistoriaClinicaAsync(Dni) != 0 ){ return "Historia clinica eliminada con exito"; }
            return "Proceso de eliminacion de historia fallido";
        }
        public static async Task<int> MostrarHistorias()
        {
            var historias = await GetHistoriasClinicas();
            foreach (var item in historias)
            {
                Console.WriteLine(item);
            }
            return 1;
        }
        public static async Task<bool> ValidarHistoria(string Dni)
        {
            var historias = await GetHistoriasClinicas();
            if (validar(Dni))
                return true;
            else return false;

            bool validar(string valor)
            {
                foreach (var item in historias)
                {
                    if (item.Dni == valor)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        // METODOS DE ADMINISTRACION DE DIAGNOSTICOS
        public static async Task<List<Diagnostico>> GetDiagnosticos()
        {
            var bl = new DiagnosticoBL();
            return await bl.GetDiagnosticosAsync();
        }
        public static async Task<string> InsertarDiagnostico()
        {
            //await MostrarCitas();
            var citas = await GetCitas();
            if(citas.Count == 0) { return "Registre una cita primero"; }
            Console.WriteLine("Ingrese IdCita");
            string IdCita = Console.ReadLine();
            if (!await ValidarCita(IdCita))
            {
                return "Esta cita no existe, por favor cree una cita primero";
            }
            var cita = await BuscarCita(IdCita);
            string dni = cita.Dni;

            var bl = new DiagnosticoBL();
            var diagnostico = new Diagnostico();
            Console.WriteLine("Ingrese IdDiagnostico");
            string IdDiagnostico = Console.ReadLine();
            if (await ValidarDiagnostico(IdDiagnostico))
            {
                return "Este diagnostico ya existe, ingrese otro IdDiagnostico";
            }
            diagnostico.IdDiagnostico = IdDiagnostico;

            await MostrarMedicamentos();
            Console.WriteLine("Ingrese CodMedicamento");
            string CodMedicamento = Console.ReadLine();
            if (!await ValidarCodMedicamento(CodMedicamento))
            {
                return "Este medicamento no esta registrado, ingrese otro CodMedicamento";
            }
            diagnostico.CodMedicamento = CodMedicamento;

            await MostrarEnfermedades();
            Console.WriteLine("Ingrese CodEnfermedad");
            string CodEnfermedad = Console.ReadLine();
            if (!await ValidarCodEnfermedad(CodEnfermedad))
            {
                return "Esta enfermedad no esta registrada, ingrese otro Codigo de Enfermedad";
            }
            diagnostico.CodEnfermedad = CodEnfermedad;
            diagnostico.CMP = cita.CMP;

            if(await bl.InsertarDiagnosticoAsync(diagnostico, dni) != 0){ return "Diagnostico creado exitosamente";}
            else { return "Proceso fallido"; }
            
        }
        //public static async Task<string> InsertarDiagnostico(string dni)
        //{
        //    var bl = new DiagnosticoBL();
        //    var diagnostico = new Diagnostico();
        //    Console.WriteLine("Ingrese IdDiagnostico");
        //    string IdDiagnostico = Console.ReadLine();
        //    if (await ValidarDiagnostico(IdDiagnostico))
        //    {
        //        return "Este diagnostico ya existe, ingrese otro IdDiagnostico";
        //    }
        //    //if(!await )
        //    diagnostico.IdDiagnostico = IdDiagnostico;

        //    await MostrarMedicamentos();
        //    Console.WriteLine("Ingrese CodMedicamento");
        //    string CodMedicamento = Console.ReadLine();
        //    if (!await ValidarCodMedicamento(CodMedicamento))
        //    {
        //        return "Este medicamento no esta registrado, ingrese otro CodMedicamento";
        //    }
        //    diagnostico.CodMedicamento = CodMedicamento.ToString();

        //    await MostrarEnfermedades();
        //    Console.WriteLine("Ingrese CodEnfermedad");
        //    string CodEnfermedad = Console.ReadLine();
        //    if (!await ValidarCodEnfermedad(CodEnfermedad))
        //    {
        //        return "Esta enfermedad no esta registrada, ingrese otro Codigo de Enfermedad";
        //    }
        //    diagnostico.CodEnfermedad = CodEnfermedad;

        //    await bl.InsertarDiagnosticoAsync(diagnostico, dni);
        //    return "Diagnostico creado exitosamente";
        //}
        public static async Task<string> UpdateDiagnostico()
        {
            var citas = await GetCitas();
            if (citas.Count == 0) { return "Registre una cita primero"; }
            Console.WriteLine("Ingrese IdCita");
            string IdCita = Console.ReadLine();
            if (!await ValidarCita(IdCita))
            {
                return "Esta cita no existe, por favor cree una cita primero";
            }

            var nuevoDiagnostico = new Diagnostico();
            var cita = await BuscarCita(IdCita);
            nuevoDiagnostico.CMP = cita.CMP;

            Console.WriteLine("Ingrese IdDiagnostico");
            string IdDiagnostico = Console.ReadLine();
            if (!await ValidarDiagnostico(IdDiagnostico))
            {
                return "Ingrese Id de diagnostico valido";
            }
            nuevoDiagnostico.IdDiagnostico = IdDiagnostico;
            Console.WriteLine("Ingrese Nuevo CodMedicamento");
            string CodMedicamento = Console.ReadLine();
            if (!await ValidarCodMedicamento(CodMedicamento))
            {
                return "Este medicamento no esta registrado, ingrese otro CodMedicamento";
            }
            nuevoDiagnostico.CodMedicamento = CodMedicamento;
            await MostrarEnfermedades();
            Console.WriteLine("Ingrese CodEnfermedad");
            string CodEnfermedad = Console.ReadLine();
            if (!await ValidarCodEnfermedad(CodEnfermedad))
            {
                return "Esta enfermedad no esta registrada, ingrese otro Codigo de Enfermedad";
            }

            var bl = new DiagnosticoBL();
            nuevoDiagnostico.CodEnfermedad = CodEnfermedad;

            await bl.UpdateDiagnosticoAsync(nuevoDiagnostico);
            return "Diagnostico actualizado exitosamente";

        }
        public static async Task<string> DeleteDiagnostico()
        {
            //await Mostrar();
            var diagnosticos = await GetDiagnosticos();
            if (diagnosticos.Count == 0) { return "Registre un diagnostico primero"; }
            var bl = new DiagnosticoBL();
            Console.WriteLine("Ingrese IdDiagnostico");
            string IdDiagnostico = Console.ReadLine();
            if (!await ValidarDiagnostico(IdDiagnostico))
            {
                return "Ingrese codigo de diagnostico valido";
            }
            await bl.DeleteDiagnosticoAsync(IdDiagnostico);
            return "Diagnostico eliminado exitosamente";

        }
        public static async Task<string> MostrarDiagnosticos()
        {
            var diagnosticos = await GetDiagnosticos();
            if(diagnosticos.Count != 0)
            {
                foreach (var item in diagnosticos)
                {
                    Console.WriteLine(item);
                }
                return "Tabla diagnosticos no vacio";
            }
            else
            {
                return "Diagnosticos aún no creados";
            }
            //return 1;
        }
        public static async Task<bool> ValidarDiagnostico(string IdDiagnostico)
        {
            var diagnosticos = await GetDiagnosticos();
            if (validar(IdDiagnostico))
            {
                return true;
            }
            return false;

            bool validar(string valor)
            {
                foreach (var item in diagnosticos)
                {
                    if (item.IdDiagnostico == valor)
                    {
                        return true;
                    }
                }
                return false;
            }
        }


        // METODOS DE ADMINISTRACION DE MEDICOS
        public static async Task<List<Medico>> GetMedicos()
        {
            MedicoBL bl = new MedicoBL();
            return await bl.GetMedicosAsync();
        }
        public static async Task<string> InsertarMedico()
        {
            if (await ValidarMedico() == null)
            {
                return "Validacion de usuario incorrecta";
            }
            MedicoBL bl = new MedicoBL();
            var medico = new Medico();

            Console.WriteLine("Ingrese CMP");
            string CMP = Console.ReadLine();
            await MostrarEspecialidades();
            Console.WriteLine("Ingrese CodEspecialidad");
            string CodEspecialidad = Console.ReadLine();
            if(!await ValidarEspecialidad(CodEspecialidad)) { return "Ingrese especialidad correcta"; }
            if(await ValidarCMP(CMP) && await ValidarEspecialidad(CodEspecialidad)) { return "Medico en esa especialidad ya asignado"; }
            medico.CMP = CMP;
            medico.CodEspecialidad = CodEspecialidad;
            Console.WriteLine("Ingrese Dni");
            medico.Dni = Console.ReadLine();
            Console.WriteLine("Ingrese Nombre");
            medico.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Apellido");
            medico.Apellido = Console.ReadLine();
            if(await bl.InsertMedicoAsync(medico) != 0) { return "Creacion de medico exitosa"; }
            else { return "Creacion de medico fallida"; }

        }
        public static async Task<string> EliminarMedico()
        {
            if (await ValidarMedico() == null)
            {
                return "Validacion de usuario incorrecta";
            }
            var bl = new MedicoBL();
            Console.WriteLine("Ingrese CMP de medico a eliminar:");
            string cmp = Console.ReadLine();
            if(!await ValidarCMP(cmp)) { return "CMP de medico incorrecto o inexistente"; }
            await bl.EliminarMedicoAsync(cmp);
            return "Medico eliminado exitosamente";
        }
        public static async Task<string> ActualizarMedico()
        {
            
            var medico = await ValidarMedico();
            if(medico == null) { return "Medico no registrado"; }
            var bl = new MedicoBL();
            
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine(medico);
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("¿Qué desea modificar?");
            string opcionesPac = @"
            0) CMP
            1) CodEspecialidad.
            2) Nombre.
            3) Apellido.
            4) Dni.
            5) Ninguno.";
            Console.WriteLine(opcionesPac);
            int opciones = int.Parse(Console.ReadLine());
            switch (opciones)
            {
                case 0:
                    Console.WriteLine("Ingrese nuevo CMP:");
                    string cmp = Console.ReadLine();
                    if (await ValidarCMP(cmp)) { return "CMP ya esta en uso"; }
                    medico.CMP = cmp;
                    break;
                case 1:
                    await MostrarEspecialidades();
                    Console.WriteLine("Ingrese nuevo CodEspecialidad: ");
                    string CodEspecialidad = Console.ReadLine();
                    if (!await ValidarEspecialidad(CodEspecialidad)) { return "Especialidad incorrecta"; }
                    medico.CodEspecialidad = CodEspecialidad;
                    break;
                case 2:
                    Console.WriteLine("Ingrese nuevo Nombre: ");
                    medico.Nombre = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Ingrese nuevo Apellido: ");
                    medico.Apellido = Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Ingrese nuevo Dni:");
                    string Dni = Console.ReadLine();
                    if (!await ValidarLongitudDni(Dni)) { return "Numero de digitos no validos para Dni"; }
                    medico.Dni = Console.ReadLine();
                    break;
                case 5:
                    return "No se hicieron cambios";
                default:
                    return "Ingrese una opcion correcta";
            }

            if(await bl.ActualizarMedicoAsync(medico) != 0) { return "Medico actualizado exitosamente";}
            else { return "Proceso fallido"; }

        }
        public static async Task<Medico> ValidarMedico()
        {
            MedicoBL bl = new MedicoBL();
            Console.WriteLine("Ingrese Usuario");
            string CMP = Console.ReadLine();
            Console.WriteLine("Ingrese Contraseña");
            string Dni = Console.ReadLine();
            var listaMedicos = await GetMedicos();
            if(listaMedicos.Count != 0)
            {
                foreach(var item in listaMedicos)
                {
                    if(item.CMP == CMP && item.Dni == Dni)
                    {
                        return item;
                    }
                }
                return null; 
            }
            else
            {
                if (CMP == "admin" && Dni == "1234")
                {
                    return null;
                }
                else { return null; }
            }
        }
        public static async Task<int> MostrarMedicos()
        {
            var medicos = await GetMedicos();
            foreach (var item in medicos)
            {
                Console.WriteLine(item);
            }
            return 1;
        }
        public static async Task<bool> ValidarCMP(string cmp)
        {
            var medicos = await GetMedicos();
            if (validar(cmp))
                return true;
            else return false;

            bool validar(string valor)
            {
                foreach (var item in medicos)
                {
                    if (item.CMP == valor)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public static async Task<bool> ValidarCodEspecialidad(string CodEspecialidad)
        {
            var medicos = await GetMedicos();
            if (validar(CodEspecialidad))
                return true;
            else return false;

            bool validar(string valor)
            {
                foreach (var item in medicos)
                {
                    if (item.CodEspecialidad == valor)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public static async Task<bool> ValidarLongitudDni(string Dni)
        {
            if (Dni.Length != 8) return false;
            else return true;
        }


        //METODOS DE ADMINISTRACION DE CITAS
        public static async Task<List<Cita>> GetCitas()
        {
            var bl = new CitaBL();
            return await bl.GetCitasAsync();
        }
        public static async Task<string> GenerarCita()
        {
            CitaBL bl = new CitaBL();
            Cita cita = new Cita();
            Console.WriteLine("Ingrese Dni de paciente: ");
            string Dni = Console.ReadLine();
            if (!await ValidarLongitudDni(Dni)) { return "Error: Ingrese numero de 8 digitos"; }
            if (!await ValidarPaciente(Dni))
            {
                return "Error: Ingrese Dni de paciente existente";
            }
            var pacientes = await GetPacientes();
            var historias = await GetHistoriasClinicas();
            Paciente paciente = await BuscarPaciente(Dni);
            //if (paciente != null)
            //{
            //Console.WriteLine("Paciente encontrado");
                HistoriaClinica historia = await BuscarHistoriaClinica(Dni);
                if (historia != null)
                {
                    Console.WriteLine("Historia clinica encontrada");
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine("REGISTRO DE CITA");
                    cita.Dni = Dni;
                    cita.Nombre = paciente.Nombre;
                    cita.Apellido = paciente.Apellido;
                    Console.WriteLine("Ingrese Codigo de especialidad:");
                    string _CodEspecialidad = Console.ReadLine();
                    if(!await ValidarEspecialidad(_CodEspecialidad)){ return "Error: Ingrese CodEspecialidad valido"; }
                    cita.CodEspecialidad = _CodEspecialidad;
                    Console.WriteLine("Ingrese Codigo de Doctor (CMP):");
                    string CMP = Console.ReadLine();
                    if(!await ValidarCMP(CMP)){ return "Error: Ingrese CMP valido"; }
                    cita.CMP = CMP;
                    Console.WriteLine("Ingrese tipo Cita (Normal/Interconsulta):");
                    cita.TipoCita = Console.ReadLine();
                    Console.WriteLine("Ingrese estado de cita (Pendiente/Cancelada/Realizada):");
                    cita.EstadoCita = Console.ReadLine();

                    //Generar codigo cita
                    string zeroWord = cita.CodEspecialidad;
                    string firstWord = cita.Apellido.Substring(0, 3);
                    string secondWord = cita.Nombre.Substring(0, 3);
                    string thirdWord = cita.Dni.Substring(0, 3);
                    string fourthWord = DateTime.Now.Second.ToString();
                    cita.IdCita = zeroWord + firstWord + secondWord + thirdWord + fourthWord;
                    if(await bl.GenerarCitaAsync(cita) != 0) { return "Cita creada exitosamente para:"+cita.Nombre+" "+cita.Apellido;}
                    else { return "Error: Proceso de creacion de cita fallido"; }
                    //return await GenerarCodigoCita(cita);
                }
                else
                {
                    //Console.WriteLine("Historia clinica de paciente NO encontrado");
                    return "Cree historia clinica primero";
                }
            }
        public static async Task<string> GenerarCita(Cita cita)
        {
            CitaBL bl = new CitaBL();
            //Generar codigo cita
            string zeroWord = cita.CodEspecialidad;
            string firstWord = cita.Apellido.Substring(0, 3);
            string secondWord = cita.Nombre.Substring(0, 3);
            string thirdWord = cita.Dni.Substring(0, 3);
            string fourthWord = DateTime.Now.Second.ToString();
            cita.IdCita = zeroWord + firstWord + secondWord + thirdWord + fourthWord;
            await bl.GenerarCitaAsync(cita);
            return "Cita creada exitosamente para:" + cita.Dni;
            //return await GenerarCodigoCita(cita);
        }
        public static string GenerarCodigoCita(Cita cita)
        {
            string zeroWord = cita.CMP;
            string firstWord = cita.Apellido.Substring(0, 3);
            string secondWord = cita.Nombre.Substring(0, 3);
            string thirdWord = cita.Dni.Substring(0, 3);
            string fourthWord = DateTime.Now.Day.ToString();
            string word = zeroWord + firstWord + secondWord + thirdWord + fourthWord;
            //return word;
            return word;
        }
        public static async Task<string> EliminarCita()
        {
            Console.WriteLine("Ingrese IdCita de paciente del que desea eliminar su cita");
            string IdCita = Console.ReadLine();
            if(!await ValidarCita(IdCita)) { return "Cita no registrada o incorrecta"; }
            var bl = new CitaBL();
            await bl.EliminarCitaAsync(IdCita);
            return "Cita eliminada exitosamente";
        }
        public static async Task<Cita> BuscarCita()
        {
            Console.WriteLine("Ingrese Dni de paciente: ");
            string Dni = Console.ReadLine();
            CitaBL bl = new CitaBL();
            return await bl.BuscarCita(Dni);
        }
        public static async Task<Cita> BuscarCita(string IdCita)
        {
            var citas = await GetCitas();

            foreach (var item in citas)
            {
                if (item.IdCita == IdCita)
                {
                    return item;
                }
            }
            return null;

        }
        public static async Task<int> MostrarCitas()
        {
            var citas = await GetCitas();
            foreach (var item in citas)
            {
                Console.WriteLine(item);
            }
            return 1;
        }
        public static async Task<bool> ValidarCita(string IdCita)
        {
            var citas = await GetCitas();
            if (validar(IdCita))
            {
                return true;
            }
            return false;

            bool validar(string valor)
            {
                foreach (var item in citas)
                {
                    if (item.IdCita == valor)
                    {
                        return true;
                    }
                }
                return false;
            }
        }


        // METODOS DE ADMINISTRACION DE ESPECIALIDADES
        public static async Task<List<Especialidad>> GetEspecialidades()
        {
            EspecialidadBL bl = new EspecialidadBL();
            return await bl.GetEspecialidadesAsync();
        }
        public static async Task<string> InsertarEspecialidad()
        {
            EspecialidadBL bl = new EspecialidadBL();
            Especialidad especialidad = new Especialidad();
            Console.WriteLine("Ingrese CodEspecialidad");
            string CodEspecialidad = Console.ReadLine();
            if(await ValidarEspecialidad(CodEspecialidad))
            {
                return "Esta especialidad ya existe, ingrese otro codigo";
            }
            //if(!await )
            especialidad.CodEspecialidad = CodEspecialidad;
            Console.WriteLine("Ingrese IdEspecialidad (nombre)");
            especialidad.IdEspecialidad = Console.ReadLine();
            await bl.InsertarEspecialidadAsync(especialidad);
            return "Especialidad creada exitosamente";
        }
        public static async Task<string> UpdateEspecialidad()
        {
            EspecialidadBL bl = new EspecialidadBL();
            Especialidad nuevaEspecialidad = new Especialidad();
            Console.WriteLine("Ingrese CodEspecialidad");
            string CodEspecialidad = Console.ReadLine();
            if (!await ValidarEspecialidad(CodEspecialidad))
            {
                return "Ingrese codigo de especialidad valido";
            }
            nuevaEspecialidad.CodEspecialidad = CodEspecialidad;
            Console.WriteLine("Ingrese Nueva IdEspecialidad");
            nuevaEspecialidad.IdEspecialidad = Console.ReadLine();
            Console.WriteLine("Ingrese Nueva CodEspecialidad");
            nuevaEspecialidad.CodEspecialidad = CodEspecialidad;
            await bl.UpdateEspecialidadAsync(nuevaEspecialidad);
            return "Especialidad actualizada exitosamente";

        }
        public static async Task<string> DeleteEspecialidad()
        {
            EspecialidadBL bl = new EspecialidadBL();
            Console.WriteLine("Ingrese CodEspecialidad");
            string CodEspecialidad = Console.ReadLine();
            if (!await ValidarEspecialidad(CodEspecialidad))
            {
                return "Ingrese codigo de especialidad valido";
            }
            await bl.DeleteEspecialidadesAsync(CodEspecialidad);
            return "Especialidad eliminada exitosamente";
            
        }
        public static async Task<int> MostrarEspecialidades()
        {
            var especialidades = await GetEspecialidades();
            foreach(var item in especialidades)
            {
                Console.WriteLine(item);
            }
            return 1;
        }
        public static async Task<bool> ValidarEspecialidad(string CodEspecialidad)
        {
            var especialidades = await GetEspecialidades();
            if (validar(CodEspecialidad))
            {
                return true;
            }
            return false;

            bool validar(string valor)
            {
                foreach(var item in especialidades)
                {
                    if (item.CodEspecialidad == valor)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        // METODOS DE ADMINISTRACION DE MEDICAMENTOS
        public static async Task<List<Medicamento>> GetMedicamentos()
        {
            MedicamentoBL bl = new MedicamentoBL();
            return await bl.GetListaMedicamentosAsync();
        }
        public static async Task<string> InsertarMedicamento()
        {
            MedicamentoBL bl = new MedicamentoBL();
            Medicamento medicamento = new Medicamento();
            Console.WriteLine("Ingrese CodMedicamento");
            string CodMedicamento = Console.ReadLine();
            if(await ValidarCodMedicamento(CodMedicamento)) { return "Medicamente ya registrado"; }
            medicamento.CodMedicamento = CodMedicamento;
            Console.WriteLine("Ingrese Nombre producto");
            medicamento.NombreProducto = Console.ReadLine();
            Console.WriteLine("Ingrese Presentacion de medicamento");
            medicamento.Presentacion = Console.ReadLine();
            Console.WriteLine("Ingrese Cantidad en stock");
            medicamento.Fracciones = int.Parse(Console.ReadLine());
            await bl.InsertarMedicamentoAsync(medicamento);
            return "Medicamento nuevo creado";
        }
        public static async Task<string> UpdateMedicamento()
        {
            MedicamentoBL bl = new MedicamentoBL();
            Medicamento medicamento = new Medicamento();
            Console.WriteLine("Ingrese CodMedicamento");
            string CodMedicamento = Console.ReadLine();
            if (!await ValidarCodMedicamento(CodMedicamento)) { return "Cod de medicamento no registrado"; }
            medicamento.CodMedicamento = CodMedicamento;
            Console.WriteLine("Ingrese nuevo Nombre producto");
            medicamento.NombreProducto = Console.ReadLine();
            Console.WriteLine("Ingrese nuevo Presentacion de medicamento");
            medicamento.Presentacion = Console.ReadLine();
            Console.WriteLine("Ingrese nuevo Cantidad de medicamento");
            medicamento.Fracciones = int.Parse(Console.ReadLine());
            await bl.UpdateMedicamentoAsync(medicamento);
            return "Medicamento actualizado";
        }
        public static async Task<string> EliminarMedicamento()
        {
            var bl = new MedicamentoBL();
            Console.WriteLine("Ingrese CodMedicamento");
            string CodMedicamento = Console.ReadLine();
            if (!await ValidarCodMedicamento(CodMedicamento)) { return "Cod de medicamento no registrado"; }
            await bl.EliminarMedicamentoAsync(CodMedicamento);
            return "Medicamento eliminado exitosamente";
        }
        public static async Task<int> MostrarMedicamentos()
        {
            var medicamentos = await GetMedicamentos();
            foreach (var item in medicamentos)
            {
                Console.WriteLine(item);
            }
            return 1;
        }
        public static async Task<bool> ValidarCodMedicamento(string CodMedicamento)
        {
            var medicamentos = await GetMedicamentos();
            if (validar(CodMedicamento))
            {
                return true;
            }
            return false;

            bool validar(string valor)
            {
                foreach (var item in medicamentos)
                {
                    if (item.CodMedicamento == valor)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        // METODOS DE ADMINISTRACION DE ENFERMEDADES
        public static async Task<List<Enfermedad>> GetEnfermedades()
        {
            var bl = new EnfermedadBL();
            return await bl.GetEnfermedadesAsync();
        }
        public static async Task<string> InsertarEnfermedad()
        {
            var bl = new EnfermedadBL();
            var enfermedad = new Enfermedad();
            Console.WriteLine("Ingrese CodEnfermedad");
            string CodEnfermedad = Console.ReadLine();
            if (await ValidarCodEnfermedad(CodEnfermedad)) { return "Enfermedad ya registrada"; }
            enfermedad.CodEnfermedad = CodEnfermedad;
            Console.WriteLine("Ingrese Descripcion de enfermedad");
            enfermedad.Descripcion = Console.ReadLine();

            await bl.InsertarEnfermedadAsync(enfermedad);
            return "Enfermedad nueva registrada";
        }
        public static async Task<string> ActualizarEnfermedad()
        {
            var bl = new EnfermedadBL();
            var enfermedad = new Enfermedad();
            Console.WriteLine("Ingrese CodEnfermedad");
            string CodEnfermedad = Console.ReadLine();
            if (!await ValidarCodEnfermedad(CodEnfermedad)) { return "Enfermedad no registrada"; }
            enfermedad.CodEnfermedad = CodEnfermedad;
            Console.WriteLine("Ingrese Descripcion de enfermedad");
            enfermedad.Descripcion = Console.ReadLine();

            await bl.UpdateEnfermedadAsync(enfermedad);
            return "Enfermedad actualizada";
        }
        public static async Task<string> EliminarEnfermedad()
        {
            var bl = new EnfermedadBL();
            Console.WriteLine("Ingrese CodEnfermedad");
            string CodEnfermedad = Console.ReadLine();
            if (!await ValidarCodEnfermedad(CodEnfermedad)) { return "Enfermedad no registrada en la base de datos"; }
            await bl.DeleteEnfermedadAsync(CodEnfermedad);
            return "Enfermedad eliminada exitosamente";
        }
        public static async Task<int> MostrarEnfermedades()
        {
            var enfermedades = await GetEnfermedades();
            foreach (var item in enfermedades)
            {
                Console.WriteLine(item);
            }
            return 1;
        }
        public static async Task<bool> ValidarCodEnfermedad(string CodEnfermedad)
        {
            var enfermedades = await GetEnfermedades();
            if (validar(CodEnfermedad))
            {
                return true;
            }
            return false;

            bool validar(string valor)
            {
                foreach (var item in enfermedades)
                {
                    if (item.CodEnfermedad == valor)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}