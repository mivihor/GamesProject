import { Component, OnChanges } from "@angular/core";
import { signUpModel } from "./signUpModel";
import { UserService } from "../user.service";
import { HttpErrorResponse } from "@angular/common/http";

@Component({
    templateUrl: './signUp.component.html',
    styleUrls: ['./signUp.component.css']
})
export class SignUpComponent {

constructor(private userService: UserService){}

userToSignUp:signUpModel = new signUpModel();
repassword:string;
ifUserCreated:boolean = true;
passLength:boolean =true;
passCheck:boolean=true;
loginCheck:boolean=true;

checkLogin():void{
    if(this.userToSignUp.login.length > 25) this.loginCheck=false;
    else this.loginCheck=true;
}

checkPasswords():void {
    if(this.repassword !== this.userToSignUp.password) this.passCheck=false;
    else this.passCheck=true;
}

checkPasswordLength():void{
    if(this.userToSignUp.password.length < 6) this.passLength=false;
    else this.passLength=true;
}

SubmitCreate(user:signUpModel){
    if(this.loginCheck == true && this.passCheck == true && this.passLength==true){
        this.userService.userCreation(user).subscribe(data =>{
            this.ifUserCreated=true;
        },
        (err:HttpErrorResponse)=>{
            this.ifUserCreated=false;
        });
    }

}
}