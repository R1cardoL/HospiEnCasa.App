using System;
using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia 
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        //campo propio tipo AppContext de la clase RepositorioPaciente
        private readonly AppContext _contexto;

        //Creamos el constructor de RepositorioPaciente
        public RepositorioPaciente(AppContext _context)
        {
            _contexto = _context;
        }

        //Metodos para realizar el CRUD
        Paciente IRepositorioPaciente.AddPaciente(Paciente paciente)
        {
            var pacienteAdicionado = _contexto.Pacientes.Add(paciente);
            _contexto.SaveChanges();
            return pacienteAdicionado.Entity;
        }

        //metodo para eliminar un paciente
        //esto es lo mismo decir public 

        void IRepositorioPaciente.DeletePaciente(int idPaciente)
        {
            var pacienteEncontrado = _contexto.Pacientes.FirstOrDefault( p => p.Id == idPaciente );
             if (pacienteEncontrado == null) return;
             _contexto.Pacientes.Remove (pacienteEncontrado);
             _contexto.SaveChanges() ;
        }

        //metodo para obtener todos los pacientes
        IEnumerable<Paciente> IRepositorioPaciente.GetAllPacientes()
        {
            return _contexto.Pacientes;
        }

        //metodo para obtener un solo paciente
        Paciente IRepositorioPaciente.GetPaciente(int idPaciente)
        {
            return _contexto.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
        }

        //metodo para actualizar un paciente
        Paciente IRepositorioPaciente.UpdatePaciente(Paciente paciente)
        {
            var pacienteEncontrado = _contexto.Pacientes.FirstOrDefault (p => p.Id == paciente.Id);
            if (pacienteEncontrado != null)
            {
                pacienteEncontrado.Nombre = paciente.Nombre;
                pacienteEncontrado.Apellidos = paciente.Apellidos;
                pacienteEncontrado.NumeroTelefono = paciente.NumeroTelefono;
                pacienteEncontrado.Genero = paciente.Genero;
                pacienteEncontrado.Direccion = paciente.Direccion;
                pacienteEncontrado.Latitud = paciente.Latitud;
                pacienteEncontrado.Longitud = paciente.Longitud;
                pacienteEncontrado.Ciudad = paciente.Ciudad;
                pacienteEncontrado.FechaNacimiento = paciente.FechaNacimiento;
                pacienteEncontrado.Familiar = paciente.Familiar;
                pacienteEncontrado.Enfermera = paciente.Enfermera;
                pacienteEncontrado.Medico = paciente.Medico;
                pacienteEncontrado.Historia = paciente.Historia;
                _contexto.SaveChanges();
            }
            return pacienteEncontrado;
        }

        //metodo para asignar medico
        Medico IRepositorioPaciente.AsignarMedico(int idPaciente, int idMedico)
        {
            var pacienteEncontrado = _contexto.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado != null)
            {
                var medicoEncontrado = _contexto.Medicos.FirstOrDefault(m => m.Id == idMedico);
                if (medicoEncontrado != null)
                {
                    pacienteEncontrado.Medico = medicoEncontrado;
                    _contexto.SaveChanges();
                }
                return medicoEncontrado;
            }
            return null;
        }
    }    

} 