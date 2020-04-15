import {SchoolUsersTableData} from "./SchoolUsersTableData";

export interface StudentDialogData extends SchoolUsersTableData{
    startYear: number;
    avgScore: number;
    absences: Map<string, Map<string, number>>;
    parentName: string;
}