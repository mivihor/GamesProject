import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AuthService } from './authorization.service';

@Injectable({
    providedIn: 'root'
})

export class AuthGuardService implements CanActivate{
    
    constructor(private auth: AuthService,
                public router: Router){}

    canActivate():boolean{
        if(!this.auth.isAuthenticated()){
            this.router.navigate(['signin']);
            return false;
        }
        return true;
    }

}