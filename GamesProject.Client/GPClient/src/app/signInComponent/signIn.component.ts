import { Component, Output, EventEmitter } from "@angular/core";
import { NgModel } from "@angular/forms";
import { Observable } from "rxjs";
import { UserService } from "../user.service";
import { userModel } from "./userModel";
import { HttpErrorResponse } from "@angular/common/http";
import { Router } from "@angular/router";
import { IsLogged } from "../IsLogged.service";



@Component({
    templateUrl: './signIn.component.html',
    styleUrls: ['./signIn.component.css']
})
export class SignInComponent{

user:userModel = new userModel();
isLoginError:boolean = false;


constructor(private uservice: UserService, 
            private router: Router,
            private isLogged:IsLogged){
}

Submit(ucred:userModel){
    //alert(`${ucred.Login}-----${ucred.Password}`);
    
    this.uservice.userAuth(ucred.Login,ucred.Password).subscribe((data:any)=>{
        sessionStorage.setItem('userToken',data.token);  
        sessionStorage.setItem('userLogin',(ucred.Login));
        this.logging(true);
        this.router.navigate(['about']);
},
    (err:HttpErrorResponse)=>{
        this.logging(false);
        this.isLoginError=true;
    });
}

logging(auth:boolean){
    this.isLogged.loggedEvent.emit(auth);
}

}