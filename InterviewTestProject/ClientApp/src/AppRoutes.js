import { AVGData, FetchData } from "./components/AVGData";
import { Home } from "./components/Home";
import { Metrics } from "./components/Metrics";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/avgdata',
        element: <AVGData />
    },
    {
        path: '/metrics',
        element: <Metrics />
    }
];

export default AppRoutes;
