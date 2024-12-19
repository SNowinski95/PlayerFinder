import './App.css'
import Layout from './components/layout/Layout'
import { createBrowserRouter, Route, createRoutesFromElements, RouterProvider } from 'react-router-dom'
import { QueryClient, QueryClientProvider } from 'react-query'
import Home from './components/Views/general/Home'
import Games from './components/Views/Game/Games'
import About from './components/Views/general/About'
import Profile from './components/Views/general/Profile'
import ErrorPage from './components/Views/general/ErrorPage'
import CreateGame from './components/Views/Game/CreateGame'
const router = createBrowserRouter(
    createRoutesFromElements(
        <Route path="/" element={<Layout /> }>
            <Route index element={<Home />} />
            <Route path="games" element={<Games />}>
                <Route path='create' element={<CreateGame/>}/>
            </Route>
            <Route path="profile" element={<Profile />} />
            <Route path="about" element={<About />} />
            <Route path="*" element={<ErrorPage/>} />
        </Route>
    )
)
const queryClient = new QueryClient();
export default function App() {
    return (
        <>
            <QueryClientProvider client={queryClient}>
            <RouterProvider router={router} />
            </QueryClientProvider>
            
        </>
    )
}
