import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { InfoComponent } from './components/info/info.component';
import { UpdateComponent } from './components/update/update.component';
import { AuthGuard } from './auth-gaurds/auth.guard';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'update',
    component: UpdateComponent,
    canActivate: [AuthGuard] 
  },
  {
    path: 'info',
    component: InfoComponent,
  },
  {
    path: '',
    redirectTo: '/info',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
