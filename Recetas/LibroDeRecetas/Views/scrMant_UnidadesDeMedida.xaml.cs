﻿using System;
using System.Collections.Generic;
using System.Windows;
using LibroDeRecetas.Datos;
using LibroDeRecetas.Models;


namespace LibroDeRecetas.Views
{
    /// <summary>
    /// Lógica de interacción para scrMant_UnidadesDeMedida.xaml
    /// </summary>
    public partial class scrMant_UnidadesDeMedida : Window
    {
        public scrMant_UnidadesDeMedida()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            this.ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            var udms = ContextoDB.Entidad_DevolverTodos<UnidadDeMedida>();
            this.dgvDatos.ItemsSource = udms;
        }

        private void MnuModificacion_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgvDatos.SelectedItem != null)
            {
                UnidadDeMedida udm = (UnidadDeMedida)this.dgvDatos.SelectedItem;
                var dlg = new dlgUnidadDeMedida_ABM(TiposDeDialogo.Modificacion, udm);
                dlg.ShowDialog();
                ActualizarGrilla();
            }              
        }

        private void MnuAlta_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new dlgUnidadDeMedida_ABM(TiposDeDialogo.Alta, null);
            dlg.ShowDialog();
            ActualizarGrilla();
        }

        private void MnuBaja_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgvDatos.SelectedItem != null)
            {
                UnidadDeMedida udm = (UnidadDeMedida)this.dgvDatos.SelectedItem;
                var dlg = new dlgUnidadDeMedida_ABM(TiposDeDialogo.Baja, udm);
                dlg.ShowDialog();
                ActualizarGrilla();
            }
        }
    }
}
