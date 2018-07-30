import { Component } from "@angular/core";
import { NgModel } from "@angular/forms";
import { Observable } from "rxjs";
import { userService } from "./user.service";
import { userModel } from "./userModel";
import { HttpErrorResponse } from "../../../node_modules/@angular/common/http";
import { JwtModule, JWT_OPTIONS } from '@auth0/angular-jwt';


@Component({
    templateUrl: './signIn.component.html',
    styleUrls: ['./signIn.component.css']
})
export class SignInComponent{
user:userModel = new userModel();
isLoginError:boolean = false;

constructor(private uservice: userService){
}

Submit(ucred:userModel){
    //alert(`${ucred.Login}-----${ucred.Password}`);
    
    this.uservice.userAuth(ucred.Login,ucred.Password).subscribe((data:any)=>{
        localStorage.setItem('userToken',data.token);    
        //router navigate ==> home
},
    (err:HttpErrorResponse)=>{
        this.isLoginError=true;
    });
}
}