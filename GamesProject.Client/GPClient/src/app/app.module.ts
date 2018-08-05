import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import {RouterModule} from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';

import { AppComponent } from './app.component';
import { SignInComponent } from './signInComponent/signIn.component';
import { AboutComponent } from './aboutComponent/about.component';
import { SignUpComponent } from './signUpComponent/signUp.component';
import { ShellGameComponent } from './shellGameComponent/shell-game.component';
import {AuthGuardService} from './auth-guard.service'
import { ShellGameChildComponent } from './shellGameComponent/shell-game.child.component';
import { JwtInterceptor } from './JwtInterceptor.service';
 


@NgModule({
  declarations: [
    AppComponent,
    SignInComponent,
    AboutComponent,
    SignUpComponent,
    ShellGameComponent,
    ShellGameChildComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    JwtModule.forRoot({
      config:{
        tokenGetter:() => {
          return sessionStorage.getItem('userToken');
        },
    
      whitelistedDomains: ['localhost:4200']
      }
    }),
    RouterModule.forRoot([
      {path:'about', component: AboutComponent},
      {path:'signin', component: SignInComponent},
      {path:'signup', component: SignUpComponent},
      {path:'shell-game',
       canActivate: [AuthGuardService],
       component: ShellGameComponent},
      {path: '', redirectTo: 'about', pathMatch: 'full'},
      {path: '**', redirectTo: 'about', pathMatch: 'full'}
    ])
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
