import { Component, OnChanges, OnInit } from '@angular/core';
import { AuthService } from './authorization.service';
import {Router} from '@angular/router'
import { Alert } from 'selenium-webdriver';
import { IsLogged } from './IsLogged.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

constructor(private authService:AuthService,
            private router: Router,
            private isLogged: IsLogged){}
authchek:boolean  = this.authService.isAuthenticated();
userLogin:string = sessionStorage.getItem('userLogin');

signOut():void{
  this.authchek=false;
  sessionStorage.clear();
  this.router.navigate(['about']);
}

ngOnInit(){
  this.isLogged.loggedEvent.subscribe((logged:boolean)=>{
    this.authchek=logged;
  })
}

}
