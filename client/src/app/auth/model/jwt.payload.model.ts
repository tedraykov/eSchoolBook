export interface JwtPayloadModel {
   nameid: string;
   userNames: string;
   schoolId: string;
   isAdmin: boolean;
   role: string;
   nbf: number
   exp: number
   iat: number
}
