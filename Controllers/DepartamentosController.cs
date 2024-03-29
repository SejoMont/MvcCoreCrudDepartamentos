﻿using Microsoft.AspNetCore.Mvc;
using MvcCoreCrudDepartamentos.Models;
using MvcCoreCrudDepartamentos.Repositories;
using System.Security.Cryptography.X509Certificates;

namespace MvcCoreCrudDepartamentos.Controllers
{
    public class DepartamentosController : Controller
    {
        RepositoryDepartamentos repo;
        public DepartamentosController()
        {
            this.repo = new RepositoryDepartamentos();
        }
        public async Task<IActionResult> Index()
        {
            List<Departamento> departamentos = await this.repo.GetDepartamentosAsync();
            return View(departamentos);
        }


        public async Task<IActionResult> Details(int id)
        {
            Departamento departamento = await this.repo.FindDepartamentoAsync(id);

            return View(departamento);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string nombre, string localidad)
        {
            await this.repo.InsertDepartamentoAsync(nombre, localidad);
            return RedirectToAction("Index");
        }

        //al mostrar el formulario de update, deberiamos dibujar los datos del departamento que estamos modificando
        public async Task<IActionResult> Edit(int id)
        {
            Departamento departamento = await this.repo.FindDepartamentoAsync(id);
            return View(departamento);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Departamento departamento)
        {
            await this.repo.UpdateDepartamentoAsync(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int iddepartamento)
        {
            await this.repo.DeleteDepartamentoAsync(iddepartamento);
            return RedirectToAction("Index");
        }
    }
}
