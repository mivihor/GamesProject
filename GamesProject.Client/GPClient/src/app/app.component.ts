import { Component } from '@angular/core';
import { AuthService } from './AuthService';
import {Router} from '@angular/router'
import { Alert } from '../../node_modules/@types/selenium-webdriver';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

constructor(private authService:AuthService,
            private router: Router){}
authchek:boolean  = this.authService.isAuthenticated();
userLogin:string = sessionStorage.getItem('userLogin');

signOut():void{
  this.authchek=false;
  sessionStorage.clear();
  this.router.navigate(['about']);
}
}
