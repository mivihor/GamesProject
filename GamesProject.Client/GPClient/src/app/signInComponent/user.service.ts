import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {  Response } from "@angular/http";
import {Observable} from 'rxjs';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

@Injectable({
    providedIn: 'root'
})
export class userService{
    authUrl:string = 'https://localhost:44307/api/auth';

    constructor(private http: HttpClient){}

    userAuth(login:string, password:string){
            const body = {"Login":login,"Password":password};
            return this.http.post(this.authUrl,body);
    }
}