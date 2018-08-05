import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from './authorization.service';

@Injectable({
    providedIn: 'root'
})
export class JwtInterceptor implements HttpInterceptor {

   
    constructor(private auth: AuthService) {}
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        
        let currentToken = sessionStorage.getItem('userToken');
        let currentUser = sessionStorage.getItem('userLogin');
        if (currentUser && currentToken && this.auth.isAuthenticated()) {
            request = request.clone({
                setHeaders: { 
                    Authorization: `Bearer ${currentToken}`
                }
            });
        }

        return next.handle(request);
    }
    }