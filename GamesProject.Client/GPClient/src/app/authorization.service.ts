import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import * as jwt_decode from "jwt-decode";

@Injectable({
    providedIn: 'root'
})

export class AuthService{
    constructor(public jwtHelper: JwtHelperService){}

    public isAuthenticated(): boolean{
        const token = sessionStorage.getItem('userToken');
        return !this.jwtHelper.isTokenExpired(token);
    }
}