import { Injectable, EventEmitter } from '@angular/core';

@Injectable({
    providedIn: 'root'
})

export class IsLogged{
    loggedEvent = new EventEmitter<boolean>();
}