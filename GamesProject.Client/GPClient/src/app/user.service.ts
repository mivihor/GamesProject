import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import {  Response, ResponseOptions } from "@angular/http";
import {Observable, throwError} from 'rxjs';
import { signUpModel } from "./signUpComponent/signUpModel";
import { ShellGameClientModel } from "./shellGameComponent/shell-game.client.model";
import { IHS } from "./HS/Ihs.model";
import {catchError, tap} from 'rxjs/operators';

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
    hsUrl:string = 'https://localhost:44300/api/highscore';


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

    getHS():Observable<IHS[]>{
        return this.http.get<IHS[]>(this.hsUrl).pipe(
            tap(data => console.log('All:'+JSON.stringify(data))),
            catchError(this.handleError)
        );
    }

    private handleError(err:HttpErrorResponse){
        let errorMessage = '';
        if(err.error instanceof ErrorEvent){
            errorMessage = `An error occured: ${err.error.message}`;
        }else{
            errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
        }
        console.error(errorMessage);
        return throwError(errorMessage);
    }

}