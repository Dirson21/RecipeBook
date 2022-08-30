import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { finalize, Observable } from "rxjs";
import { PreloadService } from "../preload.service";




@Injectable()
export class PreloadInterceptor implements HttpInterceptor
{
    constructor(private loader:PreloadService) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        this.loader.show();
        return next.handle(req).pipe(
            finalize(() => {
                this.loader.hide();
            })
        )
    }
    
}