﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AppFakeStore.Models;
using AppFakeStore.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AppFakeStore.ViewModels
{
    public class UsuarioListaViewModel : ObservableObject
    {
        private readonly IProductoService _usuariosService;

        public ObservableCollection<Usuarios> Usuarios { get; set; } = new ObservableCollection<Usuarios>();


        //PROPIEDAD DEL INDICADOR DE CARGA
        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        private bool _isDataLoaded;
        public bool IsDataLoaded
        {
            get => _isDataLoaded;
            set => SetProperty(ref _isDataLoaded, value);
        }

      

        public UsuarioListaViewModel()
        {
            _usuariosService = new ProductoService();
            _ = CargarUsuarios();
        }

        private async Task CargarUsuarios()
        {
            IsLoading = true;
            IsDataLoaded = false;

            var usuarios = await _usuariosService.GetUserAsync();
            Usuarios.Clear();
            foreach (var usuario in usuarios)
            {
                Usuarios.Add(usuario);
            }

            IsLoading = false;
            IsDataLoaded = true; 
        }
    }
}