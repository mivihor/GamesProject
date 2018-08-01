import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';

import { AppComponent } from './app.component';
import { SignInComponent } from './signInComponent/signIn.component';
import { AboutComponent } from './aboutComponent/about.component';



@NgModule({
  declarations: [
    AppComponent,
    SignInComponent,
    AboutComponent
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
      {path: '', redirectTo: 'about', pathMatch: 'full'},
      {path: '**', redirectTo: 'about', pathMatch: 'full'}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
