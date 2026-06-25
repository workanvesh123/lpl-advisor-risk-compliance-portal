import { Routes } from '@angular/router';
import { Login } from './pages/login/login';
import { Dashboard } from './pages/dashboard/dashboard';
import { Cases } from './pages/cases/cases';
import { CaseDetail } from './pages/case-detail/case-detail';
import { authGuard } from './guards/auth-guard';

export const routes: Routes = [
  { path: '', component: Login },
  { path: 'dashboard', component: Dashboard, canActivate: [authGuard] },
  { path: 'cases', component: Cases, canActivate: [authGuard] },
  { path: 'cases/:id', component: CaseDetail, canActivate: [authGuard] }
];