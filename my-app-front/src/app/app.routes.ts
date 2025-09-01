import { Routes } from '@angular/router';

export const routes: Routes = [
	{
		path: '',
		redirectTo: 'cadastro',
		pathMatch: 'full'
	},
	{
		path: 'cadastro',
		loadComponent: () => import('./components/cadastro-titulo.component').then(m => m.CadastroTituloComponent)
	},
	{
		path: 'titulos',
		loadComponent: () => import('./components/lista-titulos.component').then(m => m.ListaTitulosComponent)
	}
];
