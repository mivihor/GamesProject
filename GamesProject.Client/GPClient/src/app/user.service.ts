import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {  Response, ResponseOptions } from "@angular/http";
import {Observable} from 'rxjs';
import { signUpModel } from "./signUpComponent/signUpModel";
import { ShellGameClientModel } from "./shellGameComponent/shell-game.client.model";

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

@Injectable({
    providedIn: 'root'
})
export class UserService{
    authUrl:string = 'https://localhost:44300/api/auth';
    creationUrl:string = 'https://localhost:44300/api/create';
    userScoreUrl:string = 'https://localhost:44300/api/user-score';
    shellGameUrl: string = 'https://localhost:44300/api/shell-game';

    constructor(private http: HttpClient){}

    userAuth(login:string, password:string){
            const body = {"Login":login,"Password":password};
            return this.http.post(this.authUrl,body);
    }

    userCreation(userCreation : signUpModel){
        const bodyCreation = {"NameUCM":userCreation.name, "SurnameUCM":userCreation.surname, "LoginUCM":userCreation.login, "PasswordUCM":userCreation.password};
        return this.http.post(this.creationUrl,bodyCreation);
    }

    getUserScore(login:string){
        const userLogin = {"userLogin":login};
        return this.http.post(this.userScoreUrl, userLogin);
    }

    shellGame(gamer:ShellGameClientModel){
        const gameBody = {"Login":gamer.Login, "Bid":gamer.Bid, "userResult":gamer.userResult};
        return this.http.post(this.shellGameUrl, gameBody);
    }
}