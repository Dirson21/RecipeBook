import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { finalize, Observable } from "rxjs";
import { PreloadService } from "../preload.service";




@Injectable()
export class PreloadInterceptor implements HttpInterceptor
{
    blackList: string[] = [
        "http://localhost:4200/api/recipe/favorite/",
        "http://localhost:4200/api/recipe/like/",
        "http://localhost:4200/assets/",
        "assets\\"
    ]


    constructor(private loader:PreloadService) {

    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {


        if (this.blackList.find((value: string) => req.url.includes(value))) {
            return next.handle(req);
            
        }

        console.log(req)
        this.loader.show();
        return next.handle(req).pipe(
            finalize(() => {
                if (this.loader.loading)
                {
                    this.loader.hide();
                }
    
            })
        )
    }
    
}