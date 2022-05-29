import {Injectable} from '@angular/core';
import {HttpEvent, HttpInterceptor, HttpHandler, HttpRequest} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class APIInteceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const baseUrl = 'http://localhost:5003/'; // pull this from environment.ts or environment variable from container at startup
        let reqUrl = req.url;
        if (reqUrl.startsWith('/')) {
            reqUrl = reqUrl.substring(1);
        }
        const apiReq = req.clone({ url: `${baseUrl}${reqUrl}` });
        return next.handle(apiReq);
    }
}