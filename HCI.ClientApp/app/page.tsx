import Link from 'next/link';
import { AppBar, Toolbar, Typography } from '@mui/material';

export default function Home() {
  return (
    <main className="flex min-h-screen flex-col">
      <AppBar className="border-b border-gray-300 bg-gray-200 dark:bg-zinc-800/30" position="static">
        <Toolbar>
        <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            HCI HealthCare App
          </Typography>
        </Toolbar>
      </AppBar>
      <div className="mb-32 grid text-center items-center justify-center lg:max-w-5xl lg:w-full lg:mb-0 lg:grid-cols-4 lg:text-left p-24">
        <div className=" items-center justify-center">
          <Link href="/book-appointment">
            <h2 className={`mb-3 text-2xl font-semibold`}>
              Book Appointment{" "}
              <span className="inline-block transition-transform group-hover:translate-x-1 motion-reduce:transform-none">
                -&gt;
              </span>
            </h2>
            <div style={{ height: 200, width: 300 }}></div>
          </Link>
        </div>

        <div style={{ height: 40 }}></div>

        <div className=" items-center justify-center">
          <Link href="/view-appointment">
            <h2 className={`mb-3 text-2xl font-semibold`}>
              View Appointment{" "}
              <span className="inline-block transition-transform group-hover:translate-x-1 motion-reduce:transform-none">
                -&gt;
              </span>
            </h2>
            <div style={{ height: 200, width: 300 }}></div>
          </Link>
        </div>


      </div>
    </main>
  );
}
